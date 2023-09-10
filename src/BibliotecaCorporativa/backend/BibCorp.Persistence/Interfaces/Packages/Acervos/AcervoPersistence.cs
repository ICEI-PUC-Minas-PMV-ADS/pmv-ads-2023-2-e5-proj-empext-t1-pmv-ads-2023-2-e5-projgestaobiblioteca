
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Packages.Acervos
{
  public class AcervoPersistence : SharedPersistence, IAcervoPersistence
  {
    private readonly BibCorpContext _context;

    public AcervoPersistence(BibCorpContext context) : base(context)
    {
      _context = context;

    }
    public async Task<IEnumerable<Acervo>> GetAllAcervosAsync()
    {
      IQueryable<Acervo> query = _context.Acervos
          .Include(a => a.Patrimonios)
          .AsNoTracking()
          .OrderBy(a => a.Id);

      return await query.ToListAsync();
    }

    public async Task<Acervo> GetAcervoByIdAsync(int acervoId)
    {
      IQueryable<Acervo> query = _context.Acervos
         .Include(a => a.Patrimonios)
                .AsNoTracking()
                .Where(a => a.Id == acervoId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Acervo>> GetAcervosByISBNAsync(string ISBN)
    {
      IQueryable<Acervo> query = _context.Acervos
          .Include(a => a.Patrimonios)
            .AsNoTracking()
            .Where(a => a.ISBN == ISBN)
            .OrderBy(a => a.ISBN);

      return await query.ToListAsync();
    }
  }
}
