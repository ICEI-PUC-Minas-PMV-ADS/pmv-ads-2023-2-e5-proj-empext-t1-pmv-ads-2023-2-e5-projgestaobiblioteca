using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Usuarios
{
    public class Papel: IdentityRole<int>
    {
        public string NomeFuncao { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
    }
}
