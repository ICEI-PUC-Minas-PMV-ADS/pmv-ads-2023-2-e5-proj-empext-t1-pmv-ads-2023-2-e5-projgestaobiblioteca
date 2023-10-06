using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Domain.Models.Identity
{
    public class UsuarioPapel: IdentityUserRole<int>
    {
        public Usuario Usuario {get; set;}
        public Papel Papel { get; set; }
    }
}
