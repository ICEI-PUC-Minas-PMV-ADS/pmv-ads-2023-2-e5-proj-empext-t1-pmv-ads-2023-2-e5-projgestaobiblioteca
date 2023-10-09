using System.ComponentModel.DataAnnotations;
using BibCorp.Domain.Models.Emprestimos;

namespace BibCorp.Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Emprestimo> Emprestimos { get; set; }
    }
}
