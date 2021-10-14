using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.Entities
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [StringLength(80)]
        public string Lougradura { get; set; }
        public int Numero { get; set; }
        
        [Column(TypeName = "DateTime")]
        public DateTime DateCreate { get; set; }
        public int ClienteId { get; set; }
        public Cliente Clientes { get; set; }
    }
}