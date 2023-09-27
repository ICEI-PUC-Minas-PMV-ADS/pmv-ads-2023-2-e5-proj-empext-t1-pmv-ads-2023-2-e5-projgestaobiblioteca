using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain.Biblioteca
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Localizacao { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public IEnumerable<Emprestimo>? Emprestimos { get; set; }
    }
}