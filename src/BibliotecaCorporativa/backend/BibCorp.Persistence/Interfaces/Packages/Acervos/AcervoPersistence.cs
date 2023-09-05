using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using BibCorp.Domain.Models.Acervos;

namespace BibCorp.Persistence.Interfaces.Packages.Acervos
{
  public class AcervoPersistence : SharedPersistence, IAcervoPersistence
  {
    private readonly BibCorpContext _context;
    private readonly DashboardCargos _dashCargo = new();

    public AcervoPersistence(BibCorpContext context) : base(context)
    {
      _context = context;

    }
    public async Task<IEnumerable<Acervo>> GetAllAcervosAsync()
    {
      IQueryable<Acervo> query = _context.Acervos
          .Include(a => a.Patrimonio)
          .AsNoTracking()
          .OrderBy(c => c.Id);

      return await query.ToListAsync();
    }

    public async Task<Acervo> GetAcervoByIdAsync(int acervoId)
    {
      IQueryable<Acervo> query = _context.Acervos
         .Include(a => a.Patrimonio);
                .AsNoTracking()
                .Where(c => a.Id == cargoId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Cargo>> GetCargosByDepartamentoIdAsync(int departamentoId)
    {
      IQueryable<Cargo> query = _context.Cargos
          .Include(c => c.Empresa)
          .Include(c => c.Departamento)
          .Include(c => c.Funcionarios);

      if (departamentoId == 0)
      {
        query = query
            .AsNoTracking()
            .OrderBy(c => c.Id);
      }
      else
      {
        query = query
            .AsNoTracking()
            .Where(c => c.DepartamentoId == departamentoId)
            .OrderBy(c => c.Id);

      }

      return await query.ToListAsync();
    }
  }
}
