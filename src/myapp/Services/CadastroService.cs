using System.Collections.Generic;
using myapp.Entities;
using myapp.Repository;

namespace myapp.Service
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _iCadastroReposity;

        public CadastroService (ICadastroRepository iCadastroReposity){
            _iCadastroReposity = iCadastroReposity;
        }

        public void add(Cliente cliente)
        {
            _iCadastroReposity.add(cliente);
        }

        public void Delete(int id)
        {
            _iCadastroReposity.Delete(id);
        }

        public ICollection<Cliente> Get()
        {
            return _iCadastroReposity.Get();
        }

        public ICollection<Cliente> GetById(int id)
        {
            return _iCadastroReposity.GetById(id);
        }

        public void Update(Cliente cliente)
        {
            _iCadastroReposity.Update(cliente);
        }
    }
}