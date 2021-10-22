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
using myapp.Service;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _iCadastroService;

        public CadastroController(ICadastroService iCadastroService){
            _iCadastroService = iCadastroService;
        }

        public ActionResult<ICollection<Cliente>> Get(){
            
            var cliente =  _iCadastroService.Get().ToList();

            return cliente;
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Cliente>> Get(int id){ 

            var Cliente = _iCadastroService.GetById(id).ToList();

            return Cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente Cliente){

            Cliente.DateCreate = DateTime.Now;
            foreach (Endereco item in Cliente.Endereco)
            {
                item.DateCreate = DateTime.Now;
            }

            _iCadastroService.add(Cliente);

            return Ok("Cliente adicionado com sucesso");
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente Cliente){

            if (id != Cliente.ClienteId)
            {
                return BadRequest();
            }

          _iCadastroService.Update(Cliente);

            return Ok("Cliente Alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id){

           _iCadastroService.Delete(id);

            return Ok("Delete realizado com sucesso");
        }

    }
}