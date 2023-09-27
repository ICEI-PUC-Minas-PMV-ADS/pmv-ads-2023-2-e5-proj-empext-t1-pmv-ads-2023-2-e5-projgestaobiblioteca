using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Biblioteca;

namespace ProEventos.Persistence.Contratos
{
    public interface IUsuarioPersist
    {
       Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePatrimonios = false);
        Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false);
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePatrimonios = false); 
    }
}