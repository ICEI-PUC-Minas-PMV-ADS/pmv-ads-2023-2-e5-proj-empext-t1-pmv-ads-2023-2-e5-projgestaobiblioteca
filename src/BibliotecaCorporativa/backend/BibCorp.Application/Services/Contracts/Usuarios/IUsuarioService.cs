using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Application.Dtos.Usuarios;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Application.Services.Contracts.Usuarios
{
    public interface IUsuarioService
    {
        Task<UsuarioUpdateDto> UpdateUsuarioTokenAsync(UsuarioUpdateDto usuarioUpdateDto);
        Task<UsuarioUpdateDto> CreateUsersAsync(UsuarioDto usuarioDto);
        Task<UsuarioDto> GetUsuarioByIdAsync(int UserId);
        Task<UsuarioUpdateDto> GetUsuarioByUserNameAsync(string userName);
        Task<SignInResult> CompararSenhaUsuarioAsync(UsuarioUpdateDto usuarioUpdateDto, string senha);
        Task<bool> VerificarUsuarioExisteAsync(string userName);
    }
}
