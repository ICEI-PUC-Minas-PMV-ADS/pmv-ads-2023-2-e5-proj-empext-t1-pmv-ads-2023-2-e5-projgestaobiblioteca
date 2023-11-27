
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Domain.Exceptions;
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
  /// Obtém os dados de todos os empréstimos cadastrados na empresa
  /// </summary>
  /// <response code="200">Dados dos empréstimos cadastrados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet]
  public async Task<IActionResult> GetAllEmprestimos()
  {
    try
    {
      var emprestimos = await _emprestimoService.GetAllEmprestimosAsync();

      if (emprestimos == null) return NotFound("Não existem empréstimos cadastrados");

      return Ok(emprestimos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empréstimos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Obtém os dados de um empréstimo específico
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <response code="200">Dados do empréstimo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("{emprestimoId}")]
  public async Task<IActionResult> GetEmprestimoById(int emprestimoId)
  {
    try
    {
      var emprestimo = await _emprestimoService.GetEmprestimoByIdAsync(emprestimoId);

      if (emprestimo == null) return NotFound("Não existe empréstimo cadastrado para o Id informado");

      return Ok(emprestimo);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empréstimo por Id. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a inclusão de um novo empréstimo
  /// </summary>
  /// <response code="200">Empréstimo cadastrado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPost]
  public async Task<IActionResult> CreateEmprestimo(EmprestimoDto emprestimoDto)
  {
    try
    {
      var createdEmprestimo = await _emprestimoService.CreateEmprestimo(emprestimoDto);

      if (createdEmprestimo != null) return Ok(createdEmprestimo);

      return BadRequest("Ocorreu um erro ao tentar incluir o empréstimo");
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar empréstimo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a atualização dos dados de um empréstimo
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <param name="emprestimoDto">Empréstimo cadastrado</param>
  /// <response code="200">Empréstimo atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPut("{emprestimoId}")]
  public async Task<IActionResult> UpdateAcervo(int emprestimoId, EmprestimoDto emprestimoDto)
  {
    try
    {
      var emprestimo = await _emprestimoService.UpdateEmprestimo(emprestimoId, emprestimoDto);

      if (emprestimo == null) return NotFound("Não existe empréstimo cadastrado para o Id informado");

      return Ok(emprestimo);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar emprestimo. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza a exclusão de um empréstimo
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <response code="200">Empréstimo excluído com sucesso</response>
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
        return BadRequest("Ocorreu um erro ao tentar excluir o empréstimo");
      }
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir empréstimo. Erro: {e.Message}");
    }

  }

  /// <summary>
  /// Realiza a renovação de um empréstimo por 30 dias
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <response code="200">Empréstimo renovado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPatch("{emprestimoId}/Renovacao")]
  public async Task<IActionResult> RenovarEmprestimo(int emprestimoId)
  {
    try
    {
      var emprestimoRenovado = await _emprestimoService.RenovarEmprestimo(emprestimoId);

      if (emprestimoRenovado == null) return NotFound("Não existe empréstimo cadastrado para renovação");

      return Ok(emprestimoRenovado);
    }
    catch (CoreException e)
    {
      return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao renovar empréstimo. Erro: {e.Message}");
    }

  }
}
