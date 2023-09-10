
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Packages.Patrimonios
{
  public class PatrimonioPersistence : SharedPersistence, IPatrimonioPersistence
  {
    private readonly BibCorpContext _context;

    public PatrimonioPersistence(BibCorpContext context) : base(context)
    {
      _context = context;

    }
    public async Task<IEnumerable<Patrimonio>> GetAllPatrimoniosAsync()
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
          .AsNoTracking()
          .OrderBy(p => p.Id);

      return await query.ToListAsync();
    }

    public async Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId)
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
                .AsNoTracking()
                .Where(p => p.Id == patrimonioId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Patrimonio>> GetPatrimonioByISBNAsync(string ISBN)
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
            .AsNoTracking()
            .Where(p => p.ISBN == ISBN)
            .OrderBy(p => p.ISBN);

      return await query.ToListAsync();
    }
  }
}
