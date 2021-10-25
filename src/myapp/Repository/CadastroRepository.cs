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
                var Cadastro = (from cli in _appDbContext.Tb_Cliente
                                join eds in _appDbContext.Tb_Endereco on cli.ClienteId equals eds.ClienteId
                                select new Cadastro 
                                {
                                  Cliente = cli

                                }
                                ).AsNoTracking().ToList();

           return Cadastro;
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