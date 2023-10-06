using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Enum;

namespace BibCorp.Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public string NomeCompleto { get; set; }
        public Funcao Funcao { get; set; }
        public string Foto { get; set; }
        public string DataCadastro { get; set; }
        public string DataEncerramento { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

}
