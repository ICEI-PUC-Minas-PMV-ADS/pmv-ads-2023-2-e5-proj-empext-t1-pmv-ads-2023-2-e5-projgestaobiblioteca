using BibCorp.Application.Dto.Patrimonios;

namespace BibCorp.Application.Services.Contracts.Patrimonios
{
    public interface IPatrimonioService
    {
        Task<IEnumerable<PatrimonioDto>> GetAllPatrimoniosAsync();
        Task<PatrimonioDto> GetPatrimonioByIdAsync(int patrimonioId);
        Task<IEnumerable<PatrimonioDto>> GetPatrimonioByISBNAsync(string ISBN);
        Task<PatrimonioDto> CreatePatrimonio(PatrimonioDto patrimonioDto);
        Task<PatrimonioDto> UpdatePatrimonio (int patrimonioId, PatrimonioDto patrimonioDto);
        Task<bool> DeletePatrimonio(int patrimonioId);
    }
}
