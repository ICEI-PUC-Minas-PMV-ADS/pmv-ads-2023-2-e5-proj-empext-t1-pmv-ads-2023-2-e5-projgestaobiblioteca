
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Acervos
{
    public interface IAcervoPersistence : ISharedPersistence
    {
        Task<IEnumerable<Acervo>> GetAllAcervosAsync();
        Task<Acervo> GetAcervoByIdAsync(int acervoId);
        Task<IEnumerable<Acervo>> GetAcervosByISBNAsync(string ISBN);
    }
}
