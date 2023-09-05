using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Patrimonios
{
    public interface IPatrimonioPersistence : ISharedPersistence
    {
        Task<IEnumerable<Patrimonio>> GetAllAcervosAsync();
        Task<Patrimonio> GetACervoByIdAsync(int patrimonioId);
        Task<IEnumerable<Patrimonio>> GetPatrimonioByISBNAsync(string ISBN);
    }
}
