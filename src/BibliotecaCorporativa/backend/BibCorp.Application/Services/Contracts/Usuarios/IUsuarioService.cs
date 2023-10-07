using BibCorp.Application.Dtos.Usuarios;
using Microsoft.AspNetCore.Identity;

namespace BibCorp.Application.Services.Contracts.Usuarios
{
    public interface IUsuarioService
    {
        Task<UsuarioUpdateDto> CreateUsuario(UsuarioDto usuarioDto);
        Task<UsuarioUpdateDto> UpdateUsuario(int usuarioId, UsuarioUpdateDto usuarioUpdateDto);
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosByNomeAsync(string nome);
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId);
        Task<SignInResult> CompararSenhaUsuarioAsync(UsuarioUpdateDto usuarioUpdateDto, string password);
        Task<bool> VerificarUsuarioExisteAsync(string userName);
        Task<UsuarioUpdateDto> GetUsuarioByUserNameAsync(string userName);
    }
}
