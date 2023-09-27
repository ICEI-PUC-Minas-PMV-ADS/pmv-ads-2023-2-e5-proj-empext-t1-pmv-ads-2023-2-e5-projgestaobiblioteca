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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;

        public UsuariosController(IUsuariosService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosAsync(true);
                if (usuarios == null) return NotFound("Nenhum usuario encontrado.");

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuarios. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id, true);
                if (usuario == null) return NotFound("Usuario por Id não encontrado.");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuarios. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosByNomeAsync(nome, true);
                if (usuarios == null) return NotFound("Usuarios por titulo não encontrados.");

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar nomes. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                var usuarios = await _usuarioService.AddUsuario(model);
                if (usuarios == null) return BadRequest("Erro ao tentar adicionar usuario.");

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar usuario. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario model)
        {
            try
            {
                var usuarios = await _usuarioService.UpdateUsuario(id, model);
                if (usuarios == null) return BadRequest("Erro ao tentar adicionar usuario.");

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar usuarios. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _usuarioService.DeleteUsuario(id) ? 
                       Ok("Deletado") : 
                       BadRequest("Usuario não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar usuario. Erro: {ex.Message}");
            }
        }
    }
}
