using System.Collections.Generic;
using myapp.Entities;

namespace myapp.Model
{
    public class Cadastro
    {
        public Cliente Cliente { get; set; }

        public List<Endereco> Endereco { get; set; }
    }
}