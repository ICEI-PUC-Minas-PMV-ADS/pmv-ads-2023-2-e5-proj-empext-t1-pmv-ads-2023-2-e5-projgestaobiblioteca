using BibCorp.Application.Dtos.Usuarios;
using BibCorp.Application.Services.Contracts.Usuarios;
using BibCorp.Domain.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace BibCorp.API.Controllers.Usuarios;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
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

