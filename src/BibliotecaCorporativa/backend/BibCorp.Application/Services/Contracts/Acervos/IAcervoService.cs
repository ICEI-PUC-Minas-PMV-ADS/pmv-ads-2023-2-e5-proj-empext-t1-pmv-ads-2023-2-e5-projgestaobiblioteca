
using BibCorp.Application.Dto.Acervos;
using BibCorp.Persistence.Utilities.Pages.Class;

namespace BibCorp.Application.Services.Contracts.Acervos
{
  public interface IAcervoService
    {
        Task<IEnumerable<AcervoDto>> GetAllAcervosAsync();
        Task<AcervoDto> GetAcervoByIdAsync(int acervoId);
        Task<IEnumerable<AcervoDto>> GetAcervosByISBNAsync(string ISBN);
        Task<AcervoDto> CreateAcervo(AcervoDto acervoDto);
        Task<AcervoDto> UpdateAcervo (int acervoId, AcervoDto acervoDto);
        Task<bool> DeleteAcervo(int acervoId);
        Task<ListaDePaginas<AcervoDto>> GetAcervosRecentesAsync(ParametrosPaginacao parametrosPaginacao);
    }
}
