using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Application.Dtos.Usuarios;

namespace BibCorp.Application.Services.Contracts.Usuarios
{
    public interface ITokenService
    {
      Task<string> CreateToken(UsuarioUpdateDto usuarioUpdateDto);
    }
}
