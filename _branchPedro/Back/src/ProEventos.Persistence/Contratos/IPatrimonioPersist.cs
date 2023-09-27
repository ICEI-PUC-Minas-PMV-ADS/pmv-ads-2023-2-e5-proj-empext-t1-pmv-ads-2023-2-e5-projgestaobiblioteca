using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Biblioteca;

namespace ProEventos.Persistence.Contratos
{
    public interface IPatrimonioPersist
    {
        Task<Patrimonio[]> GetAllPatrimoniosByTituloAsync(string titulo, bool includeUsuarios = false);
        Task<Patrimonio[]> GetAllPatrimoniosAsync(bool includeUsuarios = false);
        Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId, bool includeUsuarios = false);
    }
}