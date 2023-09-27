using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Domain.Biblioteca;

namespace ProEventos.Application.Contratos
{
    public interface IPatrimonioService
    {
        Task<Patrimonio> AddPatrimonio(Patrimonio model);
        Task<Patrimonio> UpdatePatrimonio(int patrimonioId, Patrimonio model);
        Task<bool> DeletePatrimonio(int patrimonioId);

        Task<Patrimonio[]> GetAllPatrimoniosAsync(bool includePalestrantes = false);
        Task<Patrimonio[]> GetAllPatrimonioByTituloAsync(string titulo, bool includePalestrantes = false);
        Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId, bool includePalestrantes = false);
    }
}