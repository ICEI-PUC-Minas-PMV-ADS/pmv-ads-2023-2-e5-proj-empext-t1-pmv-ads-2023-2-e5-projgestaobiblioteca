
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Dtos.Emprestimos;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Domain.Exceptions;
using BibCorp.Domain.Models.Emprestimos;
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
  /// Obtém os dados dos empréstimos por usuário
  /// </summary>
  /// <param name="userName">Identificador do usuário</param>
  /// <response code="200">Dados do empréstimo consultado</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Users/{userName}")]
  public async Task<IActionResult> GetEmprestimosByUserName(string userName)
  {
    try
    {
      var emprestimo = await _emprestimoService.GetEmprestimosByUserNameAsync(userName);

      if (emprestimo == null) return NotFound("Não existe empréstimo cadastrado para o nome de usuário informado");

      return Ok(emprestimo);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empréstimo por Usuário. Erro: {e.Message}");
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
    catch (CoreException e)
    {
      return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
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

  /// <summary>
  /// Realiza a alteração do local de coleta do empréstimo
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <param name="novoLocalColeta">Novo local de coleta</param>
  /// <response code="200">Local de coleta atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPatch("{emprestimoId}/{novoLocalColeta}/AlteraLocalDeColeta")]
  public async Task<IActionResult> AlteraLocalDeColeta(int emprestimoId, string novoLocalColeta)
  {
    try
    {
      var emprestimoAlterado = await _emprestimoService.AlterarLocalDeColeta(emprestimoId, novoLocalColeta);

      if (emprestimoAlterado == null) return NotFound("Não existe empréstimo cadastrado para alteração");

      return Ok(emprestimoAlterado);
    }
    catch (CoreException e)
    {
      return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar o empréstimo. Erro: {e.Message}");
    }

  }

  /// <summary>
  /// Obtém os dados dos empréstimos por status
  /// </summary>
  /// <param name="status">Status do empréstimo</param>
  /// <response code="200">Dados dos empréstimos consultados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Status")]
  public async Task<IActionResult> GetEmprestimosByStatusAsync([FromQuery] TipoStatusEmprestimoDto[] status)
  {
    try
    {
      var emprestimos = await _emprestimoService.GetEmprestimosByStatusAsync(status);

      if (emprestimos == null) return NotFound("Não existem empréstimos cadastrados para os status informados");

      return Ok(emprestimos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empréstimos. Erro: {e.Message}");
    }
  }

  /// <summary>
  /// Realiza o gerenciamento do empréstimo
  /// </summary>
  /// <param name="emprestimoId">Identificador do empréstimo</param>
  /// <param name="gerenciamentoEmprestimo">Dados do gerenciamento</param>
  /// <response code="200">Empréstimo atualizado com sucesso</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpPatch("{emprestimoId}/GerenciamentoEmprestimo")]
  public async Task<IActionResult> GerenciarEmprestimos(int emprestimoId, [FromBody] GerenciamentoEmprestimo gerenciamentoEmprestimo)
  {
    try
    {
      var emprestimoAlterado = await _emprestimoService.GerenciarEmprestimos(emprestimoId, gerenciamentoEmprestimo);

      if (emprestimoAlterado == null) return NotFound("Não existe empréstimo cadastrado para gerenciamento");

      return Ok(emprestimoAlterado);
    }
    catch (Exception e)
    {
      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar o empréstimo. Erro: {e.Message}");
    }

  }

  /// <summary>
  /// Obtém os dados dos empréstimos por status
  /// </summary>
  /// <param name="filtroEmprestimoDto">Filtros para pesquisa dos empréstimos</param>
  /// <response code="200">Dados dos empréstimos consultados</response>
  /// <response code="400">Parâmetros incorretos</response>
  /// <response code="500">Erro interno</response>

  [HttpGet("Relatorio")]
  public async Task<IActionResult> GetEmprestimosByFiltrosAsync([FromQuery] FiltroEmprestimoDto filtroEmprestimoDto)
  {
    try
    {
      var emprestimos = await _emprestimoService.GetEmprestimosByFiltrosAsync(filtroEmprestimoDto);

      if (emprestimos == null) return NotFound("Não existem empréstimos cadastrados para os filtros informados");

      return Ok(emprestimos);
    }
    catch (Exception e)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empréstimos. Erro: {e.Message}");
    }
  }
}

