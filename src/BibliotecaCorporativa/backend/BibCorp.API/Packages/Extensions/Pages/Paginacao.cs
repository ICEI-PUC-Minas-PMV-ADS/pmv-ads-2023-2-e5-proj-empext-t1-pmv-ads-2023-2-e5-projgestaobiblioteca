using System.Text.Json;
using BibCorp.API.Utilities.Class;

namespace BibCorp.API.Packages.Extensions.Pages
{
    public static class Paginacao
    {
        public static void IncluirPaginacao(this HttpResponse response, int paginaCorrente, int itensPorPagina, int toalDeItens, int totalDePaginas)
        {
            var paginacao = new PaginacaoHeaders(paginaCorrente, itensPorPagina, toalDeItens, totalDePaginas);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            response.Headers.Add("Paginacao", JsonSerializer.Serialize(paginacao, options));

            response.Headers.Add("Access-Control-Expose-Headers", "Paginacao");
        }
    }
}