
namespace BibCorp.Application.Dtos.Usuarios
{
  public class UsuarioUpdateDto
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Localização { get; set; }
    public string FotoURL { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
  }
}
