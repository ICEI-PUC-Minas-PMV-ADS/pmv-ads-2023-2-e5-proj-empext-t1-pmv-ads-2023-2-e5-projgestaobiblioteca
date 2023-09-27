using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ProEventos.Domain.Biblioteca;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatrimoniosController : ControllerBase
    {
        private readonly IPatrimonioService _patrimonioService;

        public PatrimoniosController(IPatrimonioService patrimonioService)
        {
            _patrimonioService = patrimonioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var patrimonios = await _patrimonioService.GetAllPatrimoniosAsync(true);
                if (patrimonios == null) return NotFound("Nenhum patrimonio encontrado.");

                return Ok(patrimonios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar patrimonios. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patrimonio = await _patrimonioService.GetPatrimonioByIdAsync(id, true);
                if (patrimonio == null) return NotFound("Patrimonio por Id não encontrado.");

                return Ok(patrimonio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar patrimonios. Erro: {ex.Message}");
            }
        }

        [HttpGet("{titulo}/titulo")]
        public async Task<IActionResult> GetByTitulo(string titulo)
        {
            try
            {
                var patrimonios = await _patrimonioService.GetAllPatrimonioByTituloAsync(titulo, true);
                if (patrimonios == null) return NotFound("Patrimonios por titulo não encontrados.");

                return Ok(patrimonios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar titulos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Patrimonio model)
        {
            try
            {
                var patrimonios = await _patrimonioService.AddPatrimonio(model);
                if (patrimonios == null) return BadRequest("Erro ao tentar adicionar titulo.");

                return Ok(patrimonios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar titulos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patrimonio model)
        {
            try
            {
                var patrimonios = await _patrimonioService.UpdatePatrimonio(id, model);
                if (patrimonios == null) return BadRequest("Erro ao tentar adicionar titulo.");

                return Ok(patrimonios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar patrimonios. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _patrimonioService.DeletePatrimonio(id) ? 
                       Ok("Deletado") : 
                       BadRequest("Patrimonio não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar patrimonio. Erro: {ex.Message}");
            }
        }
    }
}
