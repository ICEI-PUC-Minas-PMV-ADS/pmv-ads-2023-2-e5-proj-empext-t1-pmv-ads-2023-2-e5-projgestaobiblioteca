using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Shared;

namespace BibCorp.Persistence.Interfaces.Contracts.Emprestimos
{
  public interface IEmprestimoPersistence : ISharedPersistence
  {
    Task<IEnumerable<Emprestimo>> GetAllEmprestimosAsync();
    Task<Emprestimo> GetACervoByIdAsync(int emprestimoId);
    Task<IEnumerable<Emprestimo>> GetEmprestimoByUserNameAsync(string UserName);
    Task<IEnumerable<Emprestimo>> GetEmprestimoByAcervoIdAsync(int AcervoId);
    Task<IEnumerable<Emprestimo>> GetEmprestimoByPatrimoniIdsync(int PatrimonioId);
  }
}
