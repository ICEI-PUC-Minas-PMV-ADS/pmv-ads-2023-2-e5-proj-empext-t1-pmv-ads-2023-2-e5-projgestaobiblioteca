using BibCorp.Domain.Models.Usuarios;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Usuarios
{
  public interface IUsuarioPersistence: ISharedPersistence
  {
    Task<IEnumerable<Usuario>> GetAllUsuariosByNomeAsync(string nome);
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task<Usuario> GetUsuarioByIdAsync(int usuarioId);
    Task<Usuario> GetUsuarioByUserNameAsync(string userName);
  }
}
