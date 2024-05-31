using RegressivaAPI.Domain.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Result<IEnumerable<Evento>>> GetAllEventos();
        Task<Result<Evento>> GetEventoById(int id);
        Task<Result<Evento>> AddEvento(Evento evento);
        Task<Result<Evento>> UpdateEvento(Evento evento);
        Task<Result> DeleteEvento(int id);
    }
}
