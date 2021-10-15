using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using myapp.Context;
using myapp.Entities;

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
                
                throw new Exception("erro ao adicionar um cliente");
            }
        }

        public void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cliente> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cliente> GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}