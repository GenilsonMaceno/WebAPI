using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapp.Context;
using myapp.Entities;
using myapp.Repository;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _ICadastroRepository;

        public CadastroController(ICadastroRepository iCadastroRepository){
            _ICadastroRepository = iCadastroRepository;
        }

        public ActionResult<ICollection<Cliente>> Get(){
            var clientes = _ICadastroRepository.Get().ToList();

            return clientes;
        }

        // [HttpGet("endereco")]
        // public ActionResult<IEnumerable<Cliente>> GetRelation(){

        //    var Clientes = _appDbContext.Tb_Cliente
        //    .AsNoTracking()
        //    .Include(e => e.Endereco)
        //    .ToList();

        //      return Clientes;

        // }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Cliente>> Get(int id){ 

            var Cliente = _ICadastroRepository.GetById(id).ToList();

            return Cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente Cliente){

            Cliente.DateCreate = DateTime.Now;
            foreach (Endereco item in Cliente.Endereco)
            {
                item.DateCreate = DateTime.Now;
            }

            _ICadastroRepository.add(Cliente);

            return Ok("Cliente adicionado com sucesso");
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente Cliente){

            if (id != Cliente.ClienteId)
            {
                return BadRequest();
            }

          _ICadastroRepository.Update(Cliente);

            // var updateCliente = _appDbContext.Update(Cliente);
            // _appDbContext.SaveChanges();

            // var viewJson = new {
            //     updateCliente.Entity.ClienteId,
            //     updateCliente.Entity.Nome,
            //     updateCliente.Entity.Email,
            //     updateCliente.Entity.Idade
            // };

            // var Json = JsonConvert.SerializeObject(viewJson);

            return Ok("Cliente Alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id){

           _ICadastroRepository.Delete(id);

            return Ok("Delete realizado com sucesso");
        }

        // [HttpGet("consultaendereco")]
        // public ActionResult<IEnumerable<Endereco>> GetEndereco(){
        //     var endereco = _appDbContext.Tb_Endereco.AsNoTracking().OrderBy(e => e.EnderecoId).Include(c => c.Clientes).ToList();


        //     return endereco;
        // }

    }
}