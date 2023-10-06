
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Packages.Patrimonios
{
  public class EmprestimoPersistence : SharedPersistence, IEmprestimoPersistence
  {
    private readonly BibCorpContext _context;

    public EmprestimoPersistence(BibCorpContext context) : base(context)
    {
      _context = context;

    }
    public async Task<IEnumerable<Emprestimo>> GetAllEmprestimosAsync()
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Acervos)
          .Include(e => e.Patrimonios)
          .AsNoTracking()
          .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<Emprestimo> GetEmprestimoByIdAsync(int emprestimoId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Acervos)
          .Include(e => e.Patrimonios)
          .AsNoTracking()
          .Where(a => a.Id == emprestimoId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByUserNameAsync(string userName)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonios)
            .AsNoTracking()
            .Where(e => e.Usuario.UserName == userName)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByAcervoIdAsync(int acervoId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonios)
            .AsNoTracking()
            .Where(e => e.AcervoId == acervoId)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByPatrimonioIdAsync(int patrimonioId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonios)
            .AsNoTracking()
            .Where(e => e.PatrimonioId == patrimonioId)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }
  }
}
