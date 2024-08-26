using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Livro
    {
        public Livro(string titulo, string autor, string iSBN, int anodePublicacao)
        {
            
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnodePublicacao = anodePublicacao;
        }

        public int Id { get; set; } 
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnodePublicacao { get; private set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
