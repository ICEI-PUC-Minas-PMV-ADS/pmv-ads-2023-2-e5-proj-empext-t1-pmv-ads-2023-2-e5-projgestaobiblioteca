using AutoMapper;
using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Application.Dtos.Emprestimos;
using BibCorp.Application.Dtos.Usuarios;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Domain.Models.Usuarios;

namespace BibCorp.Application.Config.AuotMapperConfig
{
  public class BibCorpAutoMapperConfig : Profile
  {
    public BibCorpAutoMapperConfig()
    {
      CreateMap<Acervo, AcervoDto>().ReverseMap();

      CreateMap<Patrimonio, PatrimonioDto>().ReverseMap();

      CreateMap<Emprestimo, EmprestimoDto>().ReverseMap();

      CreateMap<Usuario, UsuarioDto>().ReverseMap();
      CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
      CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
      CreateMap<FiltroEmprestimo, FiltroEmprestimoDto>().ReverseMap();
    }
  }
}
