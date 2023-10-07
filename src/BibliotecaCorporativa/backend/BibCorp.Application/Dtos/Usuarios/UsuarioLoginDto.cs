using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibCorp.Application.Dtos.Usuarios
{
    public class UsuarioLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
