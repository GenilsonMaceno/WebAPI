using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateCreate { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }


    }
}