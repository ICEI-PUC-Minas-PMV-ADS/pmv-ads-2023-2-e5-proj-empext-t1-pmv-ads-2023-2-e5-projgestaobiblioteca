
using BibCorp.API.Packages.Extensions.Pages;
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Application.Services.Contracts.Patrimonios;
using BibCorp.Persistence.Utilities.Pages.Class;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers.Patrimonios;

[ApiController]
[Route("api/[controller]")]
public class PatrimoniosController : ControllerBase
{
  private readonly IPatrimonioService _patrimonioService;

  public PatrimoniosController
  (
      IPatrimonioService patrimonioService
  )
  {
    _patrimonioService = patrimonioService;
  }


  /// <summary>
  /// Obtém os dados de todos os patrimônios cadastrados na empresa
  /// </summary>
  /// <response code="200">Dados dos patrimônios cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet]
  public async Task<IActionResult> GetAllPatrimonios()
  {
    try
    {
      var patrimonios = await _patrimonioService.GetAllPatrimoniosAsync();

      if (patrimonios == null) return NotFound("Não existem patrimônios cadastrados");

      return Ok(patrimonios);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar patrimônios. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados de um patrimônio específico
  /// </summary>
  /// <param name="patrimonioId">Identificador do patrimônio</param>
  /// <response code="200">Dados do patrimônio consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{patrimonioId}")]
  public async Task<IActionResult> GetPatrimonioById(int patrimonioId)
  {
    try
    {
      var patrimonio = await _patrimonioService.GetPatrimonioByIdAsync(patrimonioId);

      if (patrimonio == null) return NotFound("Não existe patrimônio cadastrado para o Id informado");

      return Ok(patrimonio);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar patrimônio por Id. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a inclusão de um novo patrimônio
  /// </summary>
  /// <response code="200">Patrimônio cadastrado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPost]
  public async Task<IActionResult> CreatePatrimonio(PatrimonioDto patrimonioDto)
  {
    try
    {
      var createdPatrimonio = await _patrimonioService.CreatePatrimonio(patrimonioDto);

      if (createdPatrimonio != null) return Ok(createdPatrimonio);

      return BadRequest("Ocorreu um erro ao tentar incluir o patrimônio");
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar patrimonio. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a atualização dos dados de um patrimônio
  /// </summary>
  /// <param name="patrimoniId">Identificador do patrimônio</param>
  /// <param name="patrimonioDto">Patrimônio Cadastrado</param>
  /// <response code="200">Patrimônio atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPut("{patrimonioId}")]
  public async Task<IActionResult> UpdateAcervo(int patrimonioId, PatrimonioDto patrimonioDto)
  {
    try
    {
      var patrimonio = await _patrimonioService.UpdatePatrimonio(patrimonioId, patrimonioDto);

      if (patrimonio == null) return NotFound("Não existe patrimônio cadastrado para o Id informado");

      return Ok(patrimonio);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar patrimonio. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a exclusão de um patrimônio
  /// </summary>
  /// <param name="patrimonioId">Identificador do patrimônio</param>
  /// <response code="200">Patrimônio excluído com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpDelete("{patrimonioId}")]
  public async Task<IActionResult> DeletePatrimonio(int patrimonioId)
  {
    try
    {
      if (await _patrimonioService.DeletePatrimonio(patrimonioId))
      {
        return Ok(new { message = "OK" });
      }
      else
      {
        return BadRequest("Ocorreu um erro ao tentar excluir o patrimônio");
      }
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir patrimônio. Erro: {e.Message}");
    }

  }

  
  /// <summary>
  /// Obtém os dados dos patrimonios cadastrados na emrpesa com recurso de paginacao
  /// </summary>
  /// <response code="200">Dados dos patrimonios cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Paginacao")]
  public async Task<IActionResult> GetPatrimoniosPaginacao([FromQuery]ParametrosPaginacao parametrosPaginacao)
  {
    try
    {
      var patrimonios = await _patrimonioService.GetPatrimoniosPaginacaoAsync(parametrosPaginacao);

      if (patrimonios == null) return NotFound("Não existem patrimonios cadastrados");

      Response.IncluirPaginacao(patrimonios.PaginaCorrente, patrimonios.TamanhoDaPagina, patrimonios.ContadorTotal, patrimonios.TotalDePaginas);

      return Ok(patrimonios);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar acervos. Erro: {e.Message}");
    }
  }
}
