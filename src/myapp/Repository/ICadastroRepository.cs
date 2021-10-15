using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using myapp.Context;
using myapp.Entities;

namespace myapp.Repository
{
    public interface ICadastroRepository
    {
        ICollection<Cliente> Get();
        IQueryable<Cliente> GetById();
        void add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
    }
}