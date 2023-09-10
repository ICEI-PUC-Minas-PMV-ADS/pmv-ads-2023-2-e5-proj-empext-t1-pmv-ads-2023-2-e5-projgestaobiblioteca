
using BibCorp.Application.Dto.Emprestimos;

namespace BibCorp.Application.Services.Contracts.Emprestimos
{
  public interface IEmprestimoService
  {
    Task<IEnumerable<EmprestimoDto>> GetAllEmprestimosAsync();
    Task<EmprestimoDto> GetEmprestimoByIdAsync(int emprestimoId);
    Task<IEnumerable<EmprestimoDto>> GetEmprestimosByUserNameAsync(string userName);
    Task<IEnumerable<EmprestimoDto>> GetEmprestimosByAcervoIdAsync(int acervoId);
    Task<IEnumerable<EmprestimoDto>> GetEmprestimosByPatrimonioIdAsync(int patrimonioId);
    Task<EmprestimoDto> CreateEmprestimo(EmprestimoDto acervoDto);
    Task<EmprestimoDto> UpdateEmprestimo(int emprestimoId, EmprestimoDto acervoDto);
    Task<bool> DeleteEmprestimo(int emprestimoId);
  }
}
