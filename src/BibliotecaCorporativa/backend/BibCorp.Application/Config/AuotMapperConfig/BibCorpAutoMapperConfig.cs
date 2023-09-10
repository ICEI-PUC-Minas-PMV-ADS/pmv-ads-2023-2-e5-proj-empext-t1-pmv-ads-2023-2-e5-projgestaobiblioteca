using AutoMapper;
using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Domain.Models.Patrimonios;

namespace BibCorp.Application.Config.AuotMapperConfig
{
    public class BibCorpAutoMapperConfig : Profile
    {
        public BibCorpAutoMapperConfig() {
            CreateMap<Acervo, AcervoDto>().ReverseMap();

            CreateMap<Patrimonio, PatrimonioDto>().ReverseMap();

            CreateMap<Emprestimo, EmprestimoDto>().ReverseMap();
        }
    }
}
