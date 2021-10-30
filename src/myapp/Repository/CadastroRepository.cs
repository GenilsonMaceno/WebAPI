using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myapp.Context;
using myapp.Entities;
using myapp.Model;
using Newtonsoft.Json;

namespace myapp.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly AppDbContext _appDbContext;

        public CadastroRepository(AppDbContext appDbContext){

            _appDbContext = appDbContext;

        }

        public void add(Cliente cliente)
        {
            try
            {
                 _appDbContext.Add(cliente);
                 _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                
                throw new Exception("Erro ao adicionar um cliente");
            }
        }

        public void Delete(int id)
        {
            try
            {
                 var cliente = _appDbContext.Tb_Cliente.AsNoTracking().Where(c => c.ClienteId == id).ToList();
                 _appDbContext.Remove(cliente);
                 _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                
                throw new Exception("Erro ao remover o Cliente");
            }
        }

        public ICollection<Cadastro> Get()
        {
            try
            {
                var Clientes = (from cls in _appDbContext.Tb_Cliente
                                select new Cadastro{
                                    Cliente = cls
                                }).AsNoTracking().ToList();

                var Cadastro = new List<Cadastro>();
                foreach (var item in Clientes)
                {
                    var Enderecos = _appDbContext.Tb_Endereco
                                    .Where(c => c.ClienteId == item.Cliente.ClienteId)
                                    .AsNoTracking()
                                    .ToList();
                                    
                    item.Endereco = Enderecos;
                    
                    Cadastro.Add(item);
                    
                };    

                 return Cadastro;               
                 
            }
            catch (Exception)
            {
                
                throw new Exception("Erro ao consultar o cadastro do cliente");
            }

          
        }

        public ICollection<Cliente> GetById(int id)
        {
            return _appDbContext.Tb_Cliente.AsNoTracking().Where(c => c.ClienteId == id).ToList();
        }

        public void Update(Cliente cliente)
        {
            try
            {
                 _appDbContext.Update(cliente);
                 _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                
                throw new Exception("Erro ao alterar o cliente");
            }
        }
    }
}