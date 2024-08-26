using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
