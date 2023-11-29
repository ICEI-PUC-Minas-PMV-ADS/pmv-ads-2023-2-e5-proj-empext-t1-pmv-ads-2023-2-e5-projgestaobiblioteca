using AutoMapper;
using BibCorp.Application.Dtos.Usuarios;
using BibCorp.Application.Services.Contracts.Usuarios;
using BibCorp.Domain.Models.Usuarios;
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

    public UsuarioService(
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager,
        IMapper mapper,
        IUsuarioPersistence usuarioPersist)
    {
      _usuarioPersistence = usuarioPersist;
      _userManager = userManager;
      _signInManager = signInManager;
      _mapper = mapper;

    }
    public async Task<UsuarioUpdateDto> CreateUsuario(UsuarioDto usuarioDto)
    {
      try
      {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        var usurarioCriado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

        if (usurarioCriado.Succeeded)
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

    public async Task<UsuarioUpdateDto> UpdateUsuario(UsuarioUpdateDto usuarioUpdateDto)
    {
      try
      {
        Console.WriteLine("Upodate usuario Service");
        var usuario = await _usuarioPersistence.GetUsuarioByUserNameAsync(usuarioUpdateDto.UserName);

        Console.WriteLine("Usuario " + usuario.Id);
        if (usuario == null) return null;

        _mapper.Map(usuarioUpdateDto, usuario);

        if (usuarioUpdateDto.Password != null)
        {
          var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

          await _userManager.ResetPasswordAsync(usuario, token, usuarioUpdateDto.Password);
        }

        _usuarioPersistence.Update<Usuario>(usuario);

        if (await _usuarioPersistence.SaveChangesAsync())
        {
          //opcional pois vc pode ou não retornar algo após salvar mudanças.
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

    public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosByNomeAsync(string nome)
    {
      try
      {
        var usuarios = await _usuarioPersistence.GetAllUsuariosByNomeAsync(nome);

        if (usuarios == null) return null;

        return _mapper.Map<UsuarioDto[]>(usuarios);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Contas por nome. Erro: {e.Message}");
      }
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
    {
      try
      {
        var usuarios = await _usuarioPersistence.GetAllUsuariosAsync();

        if (usuarios == null) return null;

        return _mapper.Map<UsuarioDto[]>(usuarios);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Contas. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId)
    {
      try
      {
        var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(usuarioId);

        if (usuario == null) return null;

        return _mapper.Map<UsuarioDto>(usuario);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Conta por Id da conta. Erro: {e.Message}");
      }
    }

    public async Task<UsuarioUpdateDto> GetUsuarioByUserNameAsync(string userName)
    {
      try
      {
        var usuario = await _usuarioPersistence.GetUsuarioByUserNameAsync(userName);

        if (usuario == null) return null;

        return _mapper.Map<UsuarioUpdateDto>(usuario);
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao recuperar Conta por UserName. Erro: {e.Message}");
      }
    }

    public async Task<bool> VerificarUsuarioExisteAsync(string userName)
    {
      try
      {
        return await _userManager.Users
                                 .AnyAsync(user => user.UserName.ToLower() == userName.ToLower());
      }
      catch (Exception e)
      {

        throw new Exception($"Falha ao verificar se a conta existe. Erro: {e.Message}");
      }
    }

    public async Task<SignInResult> CompararSenhaUsuarioAsync(UsuarioUpdateDto usuarioUpdateDto, string senha)
    {
      try
      {
        var usuario = await _userManager.Users
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
  }
}
