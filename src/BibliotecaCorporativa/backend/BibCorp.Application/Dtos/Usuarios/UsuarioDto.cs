using System.ComponentModel.DataAnnotations;
using BibCorp.Domain.Models.Emprestimos;

namespace BibCorp.Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Localizacao { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public IEnumerable<Emprestimo>? Emprestimos { get; set; }
    }
}
