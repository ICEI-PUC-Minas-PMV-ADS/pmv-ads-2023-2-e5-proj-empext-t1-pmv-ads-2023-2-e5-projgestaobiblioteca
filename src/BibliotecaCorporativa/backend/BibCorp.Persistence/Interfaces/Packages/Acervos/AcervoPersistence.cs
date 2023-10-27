
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using BibCorp.Persistence.Utilities.Pages.Class;
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
    public async Task<ListaDePaginas<Acervo>> GetAcervosRecentesAsync(ParametrosPaginacao parametrosPaginacao)
    {
      IQueryable<Acervo> query = _context.Acervos
          .Include(a => a.Patrimonios)
          .AsNoTracking()
          .OrderByDescending(a => a.DataCriacao);

      if (parametrosPaginacao.Genero == "Todos")
      {
        if (parametrosPaginacao.Argumento != null)
        {
          if (parametrosPaginacao.PesquisarPor == "Autor")
          {
            query = _context.Acervos
              .Where(a => a.Autor.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
          else if (parametrosPaginacao.PesquisarPor == "Resumo")
          {
            query = _context.Acervos
              .Where(a => a.Resumo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
          else if (parametrosPaginacao.PesquisarPor == "Titulo")
          {
            query = _context.Acervos
              .Where(a => a.Titulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.SubTitulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
          else
          {
            query = _context.Acervos
              .Where(a => a.Autor.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.Resumo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.Titulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.SubTitulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
        }
      }
      else if (parametrosPaginacao.Genero != null)
      {
        if (parametrosPaginacao.Argumento != null)
        {
          if (parametrosPaginacao.PesquisarPor == "Autor")
          {
            query = _context.Acervos
              .Where(a => a.Genero.ToLower().Contains(parametrosPaginacao.Genero.ToLower()) &&
                          a.Autor.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
          else if (parametrosPaginacao.PesquisarPor == "Resumo")
          {
            query = _context.Acervos
              .Where(a => a.Genero.ToLower().Contains(parametrosPaginacao.Genero.ToLower()) &&
                          a.Resumo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()));
          }
          else if (parametrosPaginacao.PesquisarPor == "Titulo")
          {
            query = _context.Acervos
              .Where(a => a.Genero.ToLower().Contains(parametrosPaginacao.Genero.ToLower()) &&
                          (a.Titulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                           a.SubTitulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower())));
          }
          else
          {
            query = _context.Acervos
              .Where(a => a.Genero.ToLower().Contains(parametrosPaginacao.Genero.ToLower()) &&
                          (a.Autor.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.Resumo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.Titulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower()) ||
                          a.SubTitulo.ToLower().Contains(parametrosPaginacao.Argumento.ToLower())));
          }
        }
        else
        {
          query = _context.Acervos
            .Where(a => a.Genero.ToLower().Contains(parametrosPaginacao.Genero.ToLower()));

        }
      }

      return await ListaDePaginas<Acervo>.CriarPaginaAsync(query, parametrosPaginacao.NumeroDaPagina, parametrosPaginacao.tamanhoDaPagina);
    }
  }

}
