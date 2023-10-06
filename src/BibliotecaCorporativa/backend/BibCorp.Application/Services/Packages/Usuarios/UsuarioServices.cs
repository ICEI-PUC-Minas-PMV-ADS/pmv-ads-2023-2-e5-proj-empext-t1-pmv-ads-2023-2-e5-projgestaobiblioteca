using AutoMapper;
using BibCorp.Application.Dtos.Usuarios;
using BibCorp.Application.Services.Contracts.Usuarios;
using BibCorp.Domain.Models.Identity;
using BibCorp.Persistence.Interfaces.Contracts.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Application.Services.Packages.Usuarios
{
  public class UsuarioService : IUsuarioService
  {
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUsuarioPersistence _usuarioPersistence;

    public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMapper mapper, IUsuarioPersistence usuarioPersistence)
    {
      _mapper = mapper;
      _usuarioPersistence = usuarioPersistence;
      _signInManager = signInManager;
      _userManager = userManager;
    }
    public async Task<SignInResult> CompararSenhaUsuarioAsync(UsuarioUpdateDto usuarioUpdateDto, string senha)
    {
      try
      {
        var usuario = await _userManager
            .Users
            .SingleOrDefaultAsync(
                usuario => usuario.UserName.ToLower() == usuarioUpdateDto.UserName.ToLower()
            );

        return await _signInManager.CheckPasswordSignInAsync(usuario, senha, false);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao validar Conta e Senha. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioUpdateDto> CreateUsersAsync(UsuarioDto usuarioDto)
    {
      try
      {
        var usuario = _mapper.Map<Usuario>(usuarioDto);

        var usuarioCriado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

        if (usuarioCriado.Succeeded)
        {
          return _mapper.Map<UsuarioUpdateDto>(usuario);
        }

        return null;
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao criar a Conta. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
    {
      try
      {
        var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);

        if (usuario == null) return null;

        return _mapper.Map<UsuarioDto>(usuario);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Contas por Id da conta. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioUpdateDto> GetUsuarioByUserNameAsync(string userName)
    {
      try
      {
        var usurio = await _usuarioPersistence.GetUsuarioByUserNameAsync(userName);

        if (usurio == null) return null;

        return _mapper.Map<UsuarioUpdateDto>(usurio);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Contas. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioUpdateDto> UpdateUsuarioTokenAsync(UsuarioUpdateDto usuarioUpdateDto)
    {
      try
      {
        var usuario = await _usuarioPersistence.GetUsuarioByUserNameAsync(usuarioUpdateDto.UserName);

        if (usuario == null) return null;

        usuarioUpdateDto.Id = usuario.Id;

        _mapper.Map(usuarioUpdateDto, usuario);

        if (usuarioUpdateDto.Password != null)
        {
          var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
          await _userManager.ResetPasswordAsync(usuario, token, usuarioUpdateDto.Password);
        }

        _usuarioPersistence.Update<Usuario>(usuario);

        if (await _usuarioPersistence.SaveChangesAsync())
        {
          var usuarioRetorno = await _usuarioPersistence.GetUsuarioByUserNameAsync(usuario.UserName);
          return _mapper.Map<UsuarioUpdateDto>(usuarioRetorno);
        }

        return null;
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao alterar Contas e token. Erro: {e.Message}");
      }
    }

    public async Task<bool> VerificarUsuarioExisteAsync(string userName)
    {
      try
      {
        return await _userManager
            .Users
            .AnyAsync(user => user.UserName.ToLower() == userName.ToLower());
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao verificar se a conta existe. Erro: {e.Message}");
      }
    }
  }
}
