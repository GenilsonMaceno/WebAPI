using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myapp.Context;
using myapp.Entities;

namespace myapp.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        public AppDbContext _appDbContext;

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

        public ICollection<Cliente> Get()
        {
           return  _appDbContext.Tb_Cliente.AsNoTracking().OrderBy(c => c.ClienteId).Include(e => e.Endereco).ToList();
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