
using AutoMapper;
using BibCorp.Domain.Exceptions;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BibCorp.Persistence.Interfaces.Packages.Patrimonios
{
  public class EmprestimoPersistence : SharedPersistence, IEmprestimoPersistence
  {
    private readonly BibCorpContext _context;
    private readonly IMapper _mapper;
    private readonly PersistenceConfiguration _persistenceConfiguration;

    public EmprestimoPersistence(BibCorpContext context, IMapper mapper, IOptions<PersistenceConfiguration> persistenceConfiguration) : base(context)
    {
      _context = context;
      _mapper = mapper;
      _persistenceConfiguration = persistenceConfiguration.Value;
    }
    public async Task<IEnumerable<Emprestimo>> GetAllEmprestimosAsync()
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Acervo)
          .Include(e => e.Patrimonio)
          .AsNoTracking()
          .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<Emprestimo> GetEmprestimoByIdAsync(int emprestimoId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Acervo)
          .Include(e => e.Patrimonio)
          .AsNoTracking()
          .Where(a => a.Id == emprestimoId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByUserNameAsync(string userName)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonio)
            .AsNoTracking()
            .Where(e => e.UserName == userName)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByAcervoIdAsync(int acervoId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonio)
            .AsNoTracking()
            .Where(e => e.AcervoId == acervoId)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByPatrimonioIdAsync(int patrimonioId)
    {
      IQueryable<Emprestimo> query = _context.Emprestimos
          .Include(e => e.Patrimonio)
            .AsNoTracking()
            .Where(e => e.PatrimonioId == patrimonioId)
            .OrderBy(e => e.Id);

      return await query.ToListAsync();
    }

    public async Task<Emprestimo> RenovarEmprestimo(int emprestimoId)
    {
      var emprestimoRenovado = _context.Emprestimos
      .AsNoTracking()
                .FirstOrDefault(e => e.Id == emprestimoId);


      var dataPrevistaDevolucaoAtual = DateTime.Parse(emprestimoRenovado.DataPrevistaDevolucao);

      var novaDataPrevistaDevolucao = dataPrevistaDevolucaoAtual.AddDays(_persistenceConfiguration.PrazoRenovacao);

      emprestimoRenovado.DataPrevistaDevolucao = novaDataPrevistaDevolucao.ToString("dd/MM/yyyy");
      emprestimoRenovado.Status = Status.Renovado;
      emprestimoRenovado.QtdeDiasEmprestimo += _persistenceConfiguration.PrazoRenovacao;

      Update(emprestimoRenovado);

      if (await SaveChangesAsync())
      {
        return emprestimoRenovado;
      }
      else throw new CoreException("Não foi possível realizar a renovação do empréstimo");


    }
  }
}
