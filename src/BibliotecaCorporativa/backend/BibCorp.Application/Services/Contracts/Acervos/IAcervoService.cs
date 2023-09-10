
using BibCorp.Application.Dto.Acervos;

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
    }
}
