using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Usuarios;

namespace BibCorp.Application.Services.Contracts.Usuarios
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuario(Usuario model);
        Task<Usuario> UpdateUsuario(int usuarioId, Usuario model);
        Task<bool> DeleteUsuario(int usuarioId);
        Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePatrimonios = false);
        Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false);
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePatrimonios = false);
    }
}
