
using System;
using System.ComponentModel.DataAnnotations;

namespace teste.Entites
{
    public class  UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Escolaridade { get; set; }
    }
}