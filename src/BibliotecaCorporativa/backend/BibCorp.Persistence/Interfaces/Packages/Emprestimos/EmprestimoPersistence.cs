
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
          .Include(e => e.Acervo)
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


      var dataPrevistaDevolucaoAtual = emprestimoRenovado.DataPrevistaDevolucao;

      var novaDataPrevistaDevolucao = dataPrevistaDevolucaoAtual.AddDays(_persistenceConfiguration.PrazoRenovacao);

      emprestimoRenovado.DataPrevistaDevolucao = novaDataPrevistaDevolucao;
      emprestimoRenovado.Status = TipoStatusEmprestimo.Renovado;
      emprestimoRenovado.QtdeDiasEmprestimo += _persistenceConfiguration.PrazoRenovacao;

      Update(emprestimoRenovado);

      if (await SaveChangesAsync())
      {
        return emprestimoRenovado;
      }
      else throw new CoreException("Não foi possível realizar a renovação do empréstimo");
    }

    public async Task<Emprestimo> AlterarLocalDeColeta(int emprestimoId, string novoLocalColeta)
    {
      var emprestimoAlterado = _context.Emprestimos
      .AsNoTracking()
                .FirstOrDefault(e => e.Id == emprestimoId);

      emprestimoAlterado.LocalDeColeta = novoLocalColeta;

      Update(emprestimoAlterado);

      if (await SaveChangesAsync())
      {
        return emprestimoAlterado;
      }
      else throw new CoreException("Não foi possível alterar o local de coleta");
    }

    public Task<IEnumerable<Emprestimo>> GetEmprestimosByStatusAsync(TipoStatusEmprestimo[] status)
    {

      var emprestimosConsultados = new List<Emprestimo>();

      foreach (var tipoStatusEmprestimo in status)
      {
        IQueryable<Emprestimo> query = _context.Emprestimos
         .Include(e => e.Acervo)
         .Include(e => e.Patrimonio)
         .AsNoTracking()
         .Where(e => e.Status == tipoStatusEmprestimo)
         .OrderBy(e => e.Id);

        emprestimosConsultados.AddRange(query);
      }
      return Task.FromResult<IEnumerable<Emprestimo>>(emprestimosConsultados);
    }

    public async Task<Emprestimo> GerenciarEmprestimos(int emprestimoId, GerenciamentoEmprestimo gerenciamentoEmprestimo)
    {
      var emprestimoAlterado = _context.Emprestimos
      .AsNoTracking()
                .FirstOrDefault(e => e.Id == emprestimoId);

      if(gerenciamentoEmprestimo.Acao == TipoAcaoEmprestimo.Aprovar )
      {
        emprestimoAlterado.Status = TipoStatusEmprestimo.Emprestado;
      }
      else if(gerenciamentoEmprestimo.Acao == TipoAcaoEmprestimo.Recusar)
      {
        emprestimoAlterado.Status = TipoStatusEmprestimo.Recusado;
      }
      else if(gerenciamentoEmprestimo.Acao == TipoAcaoEmprestimo.Devolver)
      {
        emprestimoAlterado.Status = TipoStatusEmprestimo.Devolvido;
        emprestimoAlterado.DataDevolucao = DateTime.Now;
      }

      Update(emprestimoAlterado);

      if (await SaveChangesAsync())
      {
        return emprestimoAlterado;
      }
      else throw new CoreException("Não foi possível efetuar o gerenciamento do empréstimo");
    }

    public async Task<IEnumerable<Emprestimo>> GetEmprestimosByFiltrosAsync(FiltroEmprestimo filtroEmprestimo)
    {
      if (filtroEmprestimo.Usuarios.Any()) {

        var emprestimosConsultadosPorUsuario = new List<Emprestimo>();

        foreach (var usuario in filtroEmprestimo.Usuarios)
        {
          IQueryable<Emprestimo> query = _context.Emprestimos
         .Include(e => e.Acervo)
         .Include(e => e.Patrimonio)
         .AsNoTracking()
         .Where(e => ((e.DataEmprestimo.Date >= filtroEmprestimo.DataInicio.Date && e.DataEmprestimo.Date <= filtroEmprestimo.DataFim.Date) && e.UserName == usuario))
         .OrderByDescending(e => e.DataEmprestimo);
          emprestimosConsultadosPorUsuario.AddRange(query);
        }
        return emprestimosConsultadosPorUsuario;
      }

      else
      {
        IQueryable<Emprestimo> emprestimosConsultadosPorData = _context.Emprestimos
        .Include(e => e.Acervo)
        .Include(e => e.Patrimonio)
        .AsNoTracking()
        .Where(e => (e.DataEmprestimo.Date >= filtroEmprestimo.DataInicio.Date && e.DataEmprestimo.Date <= filtroEmprestimo.DataFim.Date))
        .OrderByDescending(e => e.DataEmprestimo);

        return await emprestimosConsultadosPorData.ToListAsync();
      }

    }
  }
}
