using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Identity
{
    public class Papel: IdentityRole<int>
    {
        public string NomeFuncao { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
    }
}
