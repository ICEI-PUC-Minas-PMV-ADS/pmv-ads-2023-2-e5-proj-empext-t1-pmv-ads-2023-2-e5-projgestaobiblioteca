
using BibCorp.API.Packages.Extensions.Pages;
using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Services.Contracts.Acervos;
using BibCorp.Persistence.Utilities.Pages.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BibCorp.API.Controllers.Acervos;

[ApiController]
[Route("api/[controller]")]
public class AcervoController : ControllerBase
{
  private readonly IAcervoService _acervoService;

  public AcervoController
  (
      IAcervoService acervoService
  )
  {
    _acervoService = acervoService;
  }


  /// <summary>
  /// Obtém os dados de todos os acervos cadastrado na empresa
  /// </summary>
  /// <response code="200">Dados dos acervos cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet]
  public async Task<IActionResult> GetAllAcervos()
  {
    try
    {
      var acervos = await _acervoService.GetAllAcervosAsync();

      if (acervos == null) return NotFound("Não existem acervos cadastrados");

      return Ok(acervos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados de um acervo específico
  /// </summary>
  /// <param name="acervoId">Identificador do acervo</param>
  /// <response code="200">Dados do acervo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{acervoId}")]
  public async Task<IActionResult> GetAcervoById(int acervoId)
  {
    try
    {
      var acervo = await _acervoService.GetAcervoByIdAsync(acervoId);

      if (acervo == null) return NotFound("Não existe acervo cadastrado para o Id informado");

      return Ok(acervo);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervo por Id. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados dos acervos associados à um ISBN
  /// </summary>
  /// <param name="ISBN">Identificador do acervo</param>
  /// <response code="200">Dados do acervo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{ISBN}/isbn")]
  public async Task<IActionResult> GetAcervoByISBN(string ISBN)
  {
    try
    {
      var acervos = await _acervoService.GetAcervoByISBNAsync(ISBN);

      return Ok(acervos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervo por ISBN. Erro: {e.Message}");
    }
  }
  /// <summary>
  /// Realiza a inclusão de um novo acervo
  /// </summary>
  /// <response code="200">Acervo cadastrado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPost]
  public async Task<IActionResult> CreateAcervo(AcervoDto acervoDto)
  {
    try
    {
      Console.WriteLine("create Acervo");
      var acervo = await _acervoService.GetAcervoByISBNAsync(acervoDto.ISBN);

      if (acervo != null) return BadRequest("Já existe um Acervo com o ISBN informado");

      var createdAcervo = await _acervoService.CreateAcervo(acervoDto);

      if (createdAcervo != null) return Ok(createdAcervo);

      return BadRequest("Ocorreu um erro ao tentar incluir o acervo");
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar acervo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a atualização dos dados de um acervo
  /// </summary>
  /// <param name="acervoId">Identificador do acervo</param>
  /// <param name="acervoDto">Acervo cadastrado</param>
  /// <response code="200">Acervo atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPut("{acervoId}")]
  public async Task<IActionResult> UpdateAcervo(int acervoId, AcervoDto acervoDto)
  {
    try
    {
      var acervo = await _acervoService.UpdateAcervo(acervoId, acervoDto);

      if (acervo == null) return NotFound("Não existe acervo cadastrado para o Id informado");

      return Ok(acervo);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar acervo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a exclusão de um acervo
  /// </summary>
  /// <param name="acervoId">Identificador do acervo</param>
  /// <response code="200">Acervo excluído com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpDelete("{acervoId}")]
  public async Task<IActionResult> DeleteAcervo(int acervoId)
  {
    try
    {
      if (await _acervoService.DeleteAcervo(acervoId))
      {
        return Ok(new { message = "OK" });
      }
      else
      {
        return BadRequest("Ocorreu um erro ao tentar excluir o acervo");
      }
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir acervo. Erro: {e.Message}");
    }

  }

  /// <summary>
  /// Obtém os dados dos acervos cadastrados recentemente na emrpesa
  /// </summary>
  /// <response code="200">Dados dos acervos cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Recentes")]
  public async Task<IActionResult> GetAcervosRecentes([FromQuery] ParametrosPaginacao parametrosPaginacao)
  {
    try
    {
      var acervos = await _acervoService.GetAcervosRecentesAsync(parametrosPaginacao);

      if (acervos == null) return NotFound("Não existem acervos cadastrados");

      Response.IncluirPaginacao(acervos.PaginaCorrente, acervos.TamanhoDaPagina, acervos.ContadorTotal, acervos.TotalDePaginas);

      return Ok(acervos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados dos acervos cadastrados na emrpesa
  /// </summary>
  /// <response code="200">Dados dos acervos cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Paginacao")]
  public async Task<IActionResult> GetAcervosPaginacao([FromQuery] ParametrosPaginacao parametrosPaginacao)
  {
    try
    {
      var acervos = await _acervoService.GetAcervosRecentesAsync(parametrosPaginacao);

      if (acervos == null) return NotFound("Não existem acervos cadastrados");

      Response.IncluirPaginacao(acervos.PaginaCorrente, acervos.TamanhoDaPagina, acervos.ContadorTotal, acervos.TotalDePaginas);

      return Ok(acervos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a consulta dos acervos no Google Books
  /// </summary>
  /// <param name="isbn">número ISBN</param>
  /// <response code="200">Consulta ao Google Books realizada</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("External/{isbn}/googlebooks")]
  public async Task<IActionResult> GetAcervosGoogleBooks(string isbn)
  {
    try
    {
      var apikey = "AIzaSyAdqmSh-H-FC5TXVVEW0QBZaafCi7kI24E";
      var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}";

      using (var httpClient = new HttpClient())
      {
        var response = await httpClient.GetStringAsync(url);
        var BooksInfo = JObject.Parse(response);

        if (!BooksInfo["items"].HasValues)
        {
          return null;
        }

        string selfLink = BooksInfo["items"][0]["selfLink"].ToString();

        response = await httpClient.GetStringAsync(selfLink);
        var googleBooksInfo = JObject.Parse(response);

        var volumeInfo = googleBooksInfo["volumeInfo"];


        string dataString = volumeInfo["publishedDate"].ToString();

        // Converter a string da data para um objeto DateTime
        DateTime dataDateTime = DateTime.ParseExact(dataString, "yyyy-MM-dd", null);
        Console.WriteLine(selfLink);

        // Extrair o ano da data
        string anoPublicacao = dataDateTime.Year.ToString();

        var acervoDto = new AcervoDto
        {
          ISBN = volumeInfo["industryIdentifiers"]
                .FirstOrDefault(x => x["type"].ToString() == "ISBN_13")?["identifier"].ToString(),
          Titulo = volumeInfo["title"].ToString(),
          SubTitulo = volumeInfo["subtitle"]?.ToString(),
          Autor = string.Join(", ", volumeInfo["authors"]),
          Resumo = volumeInfo["description"].ToString(),
          AnoPublicacao = anoPublicacao,
          Editora = volumeInfo["publisher"].ToString(),
          QtdPaginas = int.Parse(volumeInfo["pageCount"].ToString())
        };

        return Ok(acervoDto);
      }

    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervo por argumento de pesquisa. Erro: {e.Message}");
    }
  }

}
