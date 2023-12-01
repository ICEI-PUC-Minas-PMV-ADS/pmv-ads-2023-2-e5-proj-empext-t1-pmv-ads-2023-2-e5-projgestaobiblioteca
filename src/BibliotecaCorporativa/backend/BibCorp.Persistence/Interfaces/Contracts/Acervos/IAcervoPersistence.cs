
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using BibCorp.Persistence.Utilities.Pages.Class;

namespace BibCorp.Persistence.Interfaces.Contracts.Acervos
{
  public interface IAcervoPersistence : ISharedPersistence
  {
    Task<IEnumerable<Acervo>> GetAllAcervosAsync();
    Task<Acervo> GetAcervoByIdAsync(int acervoId);
    Task<Acervo> GetAcervoByISBNAsync(string ISBN);
    Task<ListaDePaginas<Acervo>> GetAcervosRecentesAsync(ParametrosPaginacao parametrosPaginacao);
    Task<ListaDePaginas<Acervo>> GetAcervosPaginacaoAsync(ParametrosPaginacao parametrosPaginacao);
    Task<bool> UpdateAcervoAposEmprestimo(int acervoId);
    Task<bool> UpdateAcervoAposDevolucaoOuRecusa(int acervoId);
  }
}
