using BibCorp.Domain.Models.Usuarios;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Usuarios
{
    public interface IUsuarioPersist
    {
       Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePatrimonios = false);
        Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false);
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePatrimonios = false);
    }
}
