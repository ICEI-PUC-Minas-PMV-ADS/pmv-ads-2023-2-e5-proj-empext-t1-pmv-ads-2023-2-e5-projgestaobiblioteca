using AutoMapper;
using BibCorp.Application.Dtos.Usuarios;
using BibCorp.Application.Services.Contracts.Usuarios;
using BibCorp.Domain.Models.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BibCorp.Application.Services.Packages;

public class TokenService : ITokenService
{
  private readonly IConfiguration _config;
  private readonly UserManager<Usuario> _userManager;
  private readonly IMapper _mapper;
  public readonly SymmetricSecurityKey _key;

  public TokenService(
      IConfiguration config,
      UserManager<Usuario> userManager,
      IMapper mapper
      )
  {
    _userManager = userManager;
    _mapper = mapper;
    _config = config;
    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokenkey"]));
  }
  public async Task<string> CreateToken(UsuarioUpdateDto usuarioUpdateDto)
  {
    try
    {
      var user = _mapper.Map<Usuario>(usuarioUpdateDto);
      var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
      var roles = await _userManager.GetRolesAsync(user);

      claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
      var tokenDescription = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(10),
        SigningCredentials = creds
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescription);

      return tokenHandler.WriteToken(token);
    }
    catch (System.Exception)
    {
      throw;
    }
  }
}
