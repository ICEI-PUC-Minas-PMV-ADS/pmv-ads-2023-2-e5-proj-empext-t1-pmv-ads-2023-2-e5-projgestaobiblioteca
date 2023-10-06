using BibCorp.Domain.Models.Identity;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Usuarios
{
    public interface IUsuarioPersistence : ISharedPersistence
    {
        Task<Usuario> GetUsuarioByIdAsync(int userId);
        Task<Usuario> GetUsuarioByUserNameAsync(string userName);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    }
}
