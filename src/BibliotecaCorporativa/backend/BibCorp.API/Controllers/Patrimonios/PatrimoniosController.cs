
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Application.Services.Contracts.Patrimonios;
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
  /// Obtém os dados de todas os patrimonios cadastrados na empresa
  /// </summary>
  /// <response code="200">Dados do patrimonio cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet]
  public async Task<IActionResult> GetAllPatrimonios()
  {
    try
    {
      var patrimonios = await _patrimonioService.GetAllPatrimoniosAsync();

      if (patrimonios == null) return NoContent();

      return Ok(patrimonios);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar patrimonios. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados de um acervo específico
  /// </summary>
  /// <param name="patrimonioId">Identificador do acervo</param>
  /// <response code="200">Dados do acervo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{patrimonioId}")]
  public async Task<IActionResult> GetPatrimonioById(int patrimonioId)
  {
    try
    {
      var patrimonio = await _patrimonioService.GetPatrimonioByIdAsync(patrimonioId);

      if (patrimonio == null) return NoContent();

      return Ok(patrimonio);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar patrimonio por Id. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a inclusão de um novo patrimonio
  /// </summary>
  /// <response code="200">Patrimonio cadastrado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPost]
  public async Task<IActionResult> CreatePatrimonio(PatrimonioDto patrimonioDto)
  {
    try
    {
      var createdPatrimonio = await _patrimonioService.CreatePatrimonio(patrimonioDto);

      if (createdPatrimonio != null) return Ok(createdPatrimonio);

      return NoContent();
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar patrimonio. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a atualização dos dados de um patrimonio
  /// </summary>
  /// <param name="patrimoniId">Identificador do patrimonio</param>
  /// <param name="patrimonioDto">Patrimonio Cadastrado</param>
  /// <response code="200">Acervo atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPut("{patrimonioId}")]
  public async Task<IActionResult> UpdateAcervo(int patrimonioId, PatrimonioDto patrimonioDto)
  {
    try
    {
      var patrimonio = await _patrimonioService.UpdatePatrimonio(patrimonioId, patrimonioDto);

      if (patrimonio == null) return NoContent();

      return Ok(patrimonio);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar patrimonio. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a exclusão de um acervo
  /// </summary>
  /// <param name="patrimonioId">Identificador do acervo</param>
  /// <response code="200">Acervo excluído com sucesso</response>
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
        return BadRequest("Falha na exclusão do patrimonio.");
      }
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir patrimonio. Erro: {e.Message}");
    }

  }
}
