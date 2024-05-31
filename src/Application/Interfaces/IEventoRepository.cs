using RegressivaAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.Application.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllEventos();
        Task<Evento> GetEventoById(int id);
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(Evento evento);
        Task<bool> DeleteEvento(int id);
    }
}
