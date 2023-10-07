using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Emprestimos;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Usuarios
{
    public class Usuario: IdentityUser<int>
    {
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public IEnumerable<Emprestimo> Emprestimos { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
    }
}
