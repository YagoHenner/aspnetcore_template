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
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            var result = await _eventoService.GetAllEventos();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var result = await _eventoService.GetEventoById(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            var result = await _eventoService.AddEvento(evento);
            return result.IsSuccess ? CreatedAtAction(nameof(GetEvento), new { id = evento.id }, evento) : BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.id)
                return BadRequest("ID mismatch");

            var result = await _eventoService.UpdateEvento(evento);
            return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var result = await _eventoService.DeleteEvento(id);
            return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
        }
    }
}
