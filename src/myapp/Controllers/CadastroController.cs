using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapp.Context;
using myapp.Entities;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CadastroController(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public ActionResult<ICollection<Cliente>> Get(){
            var clientes = _appDbContext.Tb_Cliente.AsNoTracking().OrderByDescending(c => c.ClienteId).ToList();

            return clientes;
        }

        [HttpGet("endereco")]
        public ActionResult<IEnumerable<Cliente>> GetRelation(){

           var Clientes = _appDbContext.Tb_Cliente
           .AsNoTracking()
           .Include(e => e.Endereco)
           .ToList();

             return Clientes;

        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id){ 

            var Cliente = _appDbContext.Tb_Cliente.AsNoTracking().Where(c => c.ClienteId == id).FirstOrDefault();

            return Cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente Cliente){

            Cliente.DateCreate = DateTime.Now;
            foreach (Endereco item in Cliente.Endereco)
            {
                item.DateCreate = DateTime.Now;
            }

            _appDbContext.Tb_Cliente.Add(Cliente);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente Cliente){

            if (id != Cliente.ClienteId)
            {
                return BadRequest();
            }
            

            var updateCliente = _appDbContext.Update(Cliente);
            _appDbContext.SaveChanges();

            var viewJson = new {
                updateCliente.Entity.ClienteId,
                updateCliente.Entity.Nome,
                updateCliente.Entity.Email,
                updateCliente.Entity.Idade
            };

            var Json = JsonConvert.SerializeObject(viewJson);

            return Ok(Json);
        }

        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id){

            // var Cliente = new Cliente{Id = id};

            var address = _appDbContext.Tb_Cliente.FirstOrDefault(c => c.ClienteId == id);

            _appDbContext.Remove(address);
            _appDbContext.SaveChanges();

            return Ok("Delete realizado com sucesso");
        }

    }
}