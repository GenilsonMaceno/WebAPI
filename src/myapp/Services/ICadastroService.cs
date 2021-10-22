using System.Collections.Generic;
using myapp.Entities;
using myapp.Repository;

namespace myapp.Service
{
    public interface ICadastroService
    {
        ICollection<Cliente> Get();
        ICollection<Cliente> GetById(int id);
        void add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}