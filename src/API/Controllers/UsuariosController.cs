using RegressivaAPI.Application.Interfaces;
using RegressivaAPI.Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var result = await _usuarioService.GetAllUsuarios();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var result = await _usuarioService.GetUsuarioById(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var result = await _usuarioService.AddUsuario(usuario);
            return result.IsSuccess ? CreatedAtAction(nameof(GetUsuario), new { id = usuario.id }, usuario) : BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.id)
                return BadRequest("ID mismatch");

            var result = await _usuarioService.UpdateUsuario(usuario);
            return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioService.DeleteUsuario(id);
            return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
        }
    }
}
