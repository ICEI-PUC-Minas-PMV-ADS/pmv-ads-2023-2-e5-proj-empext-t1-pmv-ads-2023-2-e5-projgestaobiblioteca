using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Acervos
{
    public interface IAcervoPersistence : ISharedPersistence
    {
        Task<IEnumerable<Acervo>> GetAllAcervosAsync();
        Task<Acervo> GetACervoByIdAsync(int acervoId);
        Task<IEnumerable<Acervo>> GetAcervoByISBNAsync(string ISBN);
    }
}
