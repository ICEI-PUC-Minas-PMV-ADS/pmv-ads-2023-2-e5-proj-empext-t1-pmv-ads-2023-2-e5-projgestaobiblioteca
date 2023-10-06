
using BibCorp.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Identity
{
    public class Usuario: IdentityUser<int>
    {
        public string NomeCompleto { get; set; }
        public Funcao Funcao { get; set; }
        public string Foto { get; set; }
        public string DataCadastro { get; set; }
        public string DataEncerramento { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis {get; set;}
    }
}
