using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Biblioteca;

namespace ProEventos.Application.Contratos
{
    public interface IUsuariosService
    {
        Task<Usuario> AddUsuario(Usuario model);
        Task<Usuario> UpdateUsuario(int usuarioId, Usuario model);
        Task<bool> DeleteUsuario(int usuarioId);
        Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePatrimonios = false);
        Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false);
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePatrimonios = false); 
    }
}