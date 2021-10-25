using System.Collections.Generic;
using myapp.Entities;
using myapp.Model;
using myapp.Repository;

namespace myapp.Service
{
    public interface ICadastroService
    {
        ICollection<Cadastro> Get();
        ICollection<Cliente> GetById(int id);
        void add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}