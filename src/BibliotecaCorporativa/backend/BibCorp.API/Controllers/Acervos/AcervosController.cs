
using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Services.Contracts.Acervos;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers.Acervos;

[ApiController]
[Route("api/[controller]")]
public class AcervosController : ControllerBase
{
  private readonly IAcervoService _acervoService;
  private readonly HttpClient _httpClient = new();
  private AcervoGoogleBooksDto _googleBooksDto = new();
  private readonly AcervoDto _acervoDto = new();

  public AcervosController
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
      var acervos = await _acervoService.GetAcervosByISBNAsync(ISBN);

      if (acervos == null) return NotFound("Não existe acervos associados ao ISBN informado");

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

/*
  /// <summary>
  /// Realiza a consulta dos acervos no Google Books
  /// </summary>
  /// <param name="arg">argumento de pesquisa </param>
  /// <response code="200">Consulta ao Google Books realizada</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{arg}/googlebooks")]
  public Task<IActionResult> GetAcervosGoogleBooks(string arg)
  {
    try
    {
      var url = $"https://www.googleapis.com/books/v1/volumes?q={arg}";

      _httpClient.BaseAddress = new Uri(url);

      _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("consultar-googlebooks/json"));

      System.Net.Http.HttpResponseMessage response = _httpClient.GetAsync(url).Result;

      _googleBooksDto = response.Content.ReadFromJsonAsync<AcervoGoogleBooksDto>().Result;

      if (response.IsSuccessStatusCode)
      {

        _acervoDto.ISBN = _googleBooksDto.ISBN;

        return Ok(_acervoDto);
      }
      return BadRequest("Acervo não encontrado");
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervo por argumento de pesquisa. Erro: {e.Message}");
    }
  } */

}
