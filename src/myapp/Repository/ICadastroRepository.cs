using System.Collections.Generic;
using myapp.Entities;
using myapp.Model;

namespace myapp.Repository
{
    public interface ICadastroRepository 
    {
        ICollection<Cadastro> Get();
        ICollection<Cliente> GetById(int id);
        void add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}