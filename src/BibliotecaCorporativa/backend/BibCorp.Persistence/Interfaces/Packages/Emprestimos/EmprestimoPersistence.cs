
using AutoMapper;
using BibCorp.Domain.Models.Acervos;
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
    private readonly IMapper _mapper;

    public EmprestimoPersistence(BibCorpContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;

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
            .Where(e => e.UserName == userName)
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

    public async Task<Emprestimo> RenovarEmprestimo(int emprestimoId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
      .AsNoTracking()
                .Where(e => e.Id == emprestimoId);

      try
      {
        var emprestimoRenovado = _mapper.Map<Emprestimo>(query.ToArrayAsync().Result.ElementAt(0));

        DateTime dataPrevistaDevolucaoAtual = DateTime.Parse(emprestimoRenovado.DataPrevistaDevolucao);

        DateTime novaDataPrevistaDevolucao = dataPrevistaDevolucaoAtual.AddDays(30);

        emprestimoRenovado.DataPrevistaDevolucao = novaDataPrevistaDevolucao.ToString("dd/MM/yyyy");
        emprestimoRenovado.Status = Status.Renovado;
        emprestimoRenovado.QtdeDiasEmprestimo = emprestimoRenovado.QtdeDiasEmprestimo + 30;

        Update(emprestimoRenovado);

        if (await SaveChangesAsync())
        {
          return emprestimoRenovado;
        }
        else throw new Exception("Não foi possível realizar a renovação do empréstimo");
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
