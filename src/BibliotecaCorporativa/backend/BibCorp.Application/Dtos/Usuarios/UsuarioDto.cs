using BibCorp.Domain.Models.Emprestimos;

namespace BibCorp.Application.Dtos.Usuarios
{
  public class UsuarioDto
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Localizacao { get; set; }
    public string FotoURL { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public IEnumerable<Emprestimo> Emprestimos { get; set; }
  }
}
