
using AutoMapper;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using BibCorp.Persistence.Utilities.Pages.Class;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Packages.Patrimonios
{
  public class PatrimonioPersistence : SharedPersistence, IPatrimonioPersistence
  {
    private readonly BibCorpContext _context;
    private readonly IMapper _mapper;

    public PatrimonioPersistence(BibCorpContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<IEnumerable<Patrimonio>> GetAllPatrimoniosAsync()
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
          .Include(p => p.Acervo)
          .AsNoTracking()
          .OrderBy(p => p.Id);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Patrimonio>> GetAllPatrimoniosLivresAsync(string isbn)
    {
      Console.WriteLine(isbn);
      IQueryable<Patrimonio> query = _context.Patrimonios
          .Include(p => p.Acervo)
          .AsNoTracking()
          .Where(p => p.ISBN == isbn && p.AcervoId == null)
          .OrderBy(p => p.Id);

      return await query.ToListAsync();
    }

    public async Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId)
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
        .Include(p => p.Acervo)
        .AsNoTracking()
        .Where(p => p.Id == patrimonioId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Patrimonio>> GetPatrimoniosByISBNAsync(string ISBN)
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
            .Include(p => p.Acervo)
            .AsNoTracking()
            .Where(p => p.ISBN == ISBN)
            .OrderBy(p => p.ISBN);

      return await query.ToListAsync();
    }
    public async Task<ListaDePaginas<Patrimonio>> GetPatrimoniosPaginacaoAsync(ParametrosPaginacao parametrosPaginacao)
    {
      IQueryable<Patrimonio> query = _context.Patrimonios
          .Include(p => p.Acervo)
          .AsNoTracking();
      if (parametrosPaginacao.Argumento != null)
      {
        Console.WriteLine("arg: " + parametrosPaginacao.Argumento + " pesquisarPor: " + parametrosPaginacao.PesquisarPor + " genero: " + parametrosPaginacao.Genero);
        if (parametrosPaginacao.PesquisarPor == "Localizacao")
        {
          query = _context.Patrimonios
            .Where(a => a.Localizacao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "Sala")
        {
          query = _context.Patrimonios
            .Where(a => a.Sala.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "Coluna")
        {
          query = _context.Patrimonios
            .Where(a => a.Coluna.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "Prateleira")
        {
          query = _context.Patrimonios
            .Where(a => a.Prateleira.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "Posicao")
        {
          query = _context.Patrimonios
            .Where(a => a.Posicao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "ISBN")
        {
          query = _context.Patrimonios
            .Where(a => a.ISBN.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
        else if (parametrosPaginacao.PesquisarPor == "SituacaoEmprestado")
        {
          query = _context.Patrimonios
         .Where(a => a.Status == true &&
                     (a.Localizacao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Sala.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Coluna.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Prateleira.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Posicao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.ISBN.ToLower().Contains(parametrosPaginacao.Argumento.ToLower())));
        }
        else if (parametrosPaginacao.PesquisarPor == "SituacaoLiberado")
        {
          query = _context.Patrimonios
         .Where(a => a.Status == false &&
                     (a.Localizacao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Sala.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Coluna.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Prateleira.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.Posicao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                     a.ISBN.ToLower().Contains(parametrosPaginacao.Argumento.ToLower())));
        }
        else
        {
          query = _context.Patrimonios
            .Where(a => a.Localizacao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                        a.Sala.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                        a.Coluna.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                        a.Prateleira.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                        a.Posicao.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                        a.ISBN.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
        }
      }
      else
      {
        if (parametrosPaginacao.PesquisarPor == "SituacaoEmprestado")
        {
          query = _context.Patrimonios
         .Where(a => a.Status == true);
        }
        else if (parametrosPaginacao.PesquisarPor == "SituacaoLiberado")
        {
          query = _context.Patrimonios
         .Where(a => a.Status == false);
        }
      }

      return await ListaDePaginas<Patrimonio>.CriarPaginaAsync(query, parametrosPaginacao.NumeroDaPagina, parametrosPaginacao.tamanhoDaPagina);
    }

    public async Task<bool> UpdatePatrimonioAposEmprestimo(int patrimonioId)
    {
      var patrimonioAlterado = _context.Patrimonios
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == patrimonioId);

      patrimonioAlterado.Status = true;
      patrimonioAlterado.DataIndisponibilidade = DateTime.Now.ToString("dd/MM/yyyy");
      patrimonioAlterado.DataAtualizacao = DateTime.Now.ToString("dd/MM/yyyy");

      Update(patrimonioAlterado);

      return await SaveChangesAsync();

    }

    public async Task<bool> UpdatePatrimonioAposDevolucaoOuRecusa(int patrimonioId)
    {
      var patrimonioAlterado = _context.Patrimonios
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == patrimonioId);

      patrimonioAlterado.Status = false;
      patrimonioAlterado.DataIndisponibilidade = null;
      patrimonioAlterado.DataAtualizacao = DateTime.Now.ToString("dd/MM/yyyy");

      Update(patrimonioAlterado);

      return await SaveChangesAsync();

    }


  }
}
