using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Utilities.Pages.Class
{
  public class ListaDePaginas<T> : List<T>
  {
    public int PaginaCorrente { get; set; }
    public int TotalDePaginas { get; set; }
    public int TamanhoDaPagina { get; set; }
    public int ContadorTotal { get; set; }

    public ListaDePaginas() {}
    public ListaDePaginas(List<T> itens, int contador, int numeroDaPagina, int tamanhoDaPagina)
    {
      ContadorTotal = contador;
      TamanhoDaPagina = tamanhoDaPagina;
      PaginaCorrente = numeroDaPagina;
      TotalDePaginas = (int)Math.Ceiling(contador / (double)tamanhoDaPagina);
      AddRange(itens);
    }

    public static async Task<ListaDePaginas<T>> CriarPaginaAsync(
        IQueryable<T> recurso, int numeroDaPagina, int tamanhoDaPagina
    )
    {
      var contador = await recurso.CountAsync();
      var itens = await recurso.Skip((numeroDaPagina - 1) * tamanhoDaPagina)
                               .Take(tamanhoDaPagina)
                               .ToListAsync();
      return new ListaDePaginas<T>(itens, contador, numeroDaPagina, tamanhoDaPagina);
    }
  }
}
