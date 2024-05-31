using RegressivaAPI.Application.Interfaces;
using RegressivaAPI.Domain.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result<IEnumerable<Evento>>> GetAllEventos()
        {
            var eventos = await _eventoRepository.GetAllEventos();
            return Result.Ok(eventos);
        }

        public async Task<Result<Evento>> GetEventoById(int id)
        {
            var evento = await _eventoRepository.GetEventoById(id);
            return evento != null ? Result.Ok(evento) : Result.Fail("Evento não encontrado");
        }

        public async Task<Result<Evento>> AddEvento(Evento evento)
        {
            var addedEvento = await _eventoRepository.AddEvento(evento);
            return Result.Ok(addedEvento);
        }

        public async Task<Result<Evento>> UpdateEvento(Evento evento)
        {
            var updatedEvento = await _eventoRepository.UpdateEvento(evento);
            return Result.Ok(updatedEvento);
        }

        public async Task<Result> DeleteEvento(int id)
        {
            var success = await _eventoRepository.DeleteEvento(id);
            return success ? Result.Ok() : Result.Fail("Erro ao deletar evento");
        }
    }
}
