
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Application.Services.Contracts.Patrimonios;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers.Emprestimos;

[ApiController]
[Route("api/[controller]")]
public class EmprestimosController : ControllerBase
{
  private readonly IEmprestimoService _emprestimoService;

  public EmprestimosController
  (
      IEmprestimoService emprestimoService
  )
  {
    _emprestimoService = emprestimoService;
  }


  /// <summary>
  /// Obtém os dados de todas os emprestimos cadastrados na empresa
  /// </summary>
  /// <response code="200">Dados do emprestimo cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet]
  public async Task<IActionResult> GetAllEmprestimos()
  {
    try
    {
      var emprestimos = await _emprestimoService.GetAllEmprestimosAsync();

      if (emprestimos == null) return NoContent();

      return Ok(emprestimos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar emprestimos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados de um emprestimo específico
  /// </summary>
  /// <param name="emprestimoId">Identificador do acervo</param>
  /// <response code="200">Dados do acervo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{emprestimoId}")]
  public async Task<IActionResult> GetEmprestimoById(int emprestimoId)
  {
    try
    {
      var emprestimo = await _emprestimoService.GetEmprestimoByIdAsync(emprestimoId);

      if (emprestimo == null) return NoContent();

      return Ok(emprestimo);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar emprestimo por Id. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a inclusão de um novo emprestimo
  /// </summary>
  /// <response code="200">Emprestimo cadastrado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPost]
  public async Task<IActionResult> CreateEmprestimo(EmprestimoDto emprestimoDto)
  {
    try
    {
      var createdEmprestimo = await _emprestimoService.CreateEmprestimo(emprestimoDto);

      if (createdEmprestimo != null) return Ok(createdEmprestimo);

      return NoContent();
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar emprestimo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a atualização dos dados de um patrimonio
  /// </summary>
  /// <param name="emprestimoId">Identificador do emprestimo</param>
  /// <param name="emprestimoDto">Emprestimo Cadastrado</param>
  /// <response code="200">Emprestimo atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPut("{emprestimoId}")]
  public async Task<IActionResult> UpdateAcervo(int emprestimoId, EmprestimoDto emprestimoDto)
  {
    try
    {
      var emprestimo = await _emprestimoService.UpdateEmprestimo(emprestimoId, emprestimoDto);

      if (emprestimo == null) return NoContent();

      return Ok(emprestimo);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar emprestimo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a exclusão de um acervo
  /// </summary>
  /// <param name="emprestimoId">Identificador do acervo</param>
  /// <response code="200">Acervo excluído com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpDelete("{emprestimoId}")]
  public async Task<IActionResult> DeleteEmprestimo(int emprestimoId)
  {
    try
    {
      if (await _emprestimoService.DeleteEmprestimo(emprestimoId))
      {
        return Ok(new { message = "OK" });
      }
      else
      {
        return BadRequest("Falha na exclusão do emprestimo.");
      }
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir emprestimo. Erro: {e.Message}");
    }

  }
}
