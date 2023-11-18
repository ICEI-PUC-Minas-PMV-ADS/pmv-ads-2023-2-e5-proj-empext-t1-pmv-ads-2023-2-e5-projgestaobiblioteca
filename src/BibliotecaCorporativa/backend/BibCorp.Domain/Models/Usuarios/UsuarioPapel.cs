using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Usuarios
{
  public class UsuarioPapel : IdentityUserRole<int>
  {
    public Usuario Usuario { get; set; }
    public Papel Papel { get; set; }
  }
}
