using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegressivaAPI.Application.Interfaces;
using RegressivaAPI.Domain.Entities;
using RegressivaAPI.Infrastructure.Data;

namespace RegressivaAPI.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllEventos()
        {
            return await _context.Eventos.Include(e => e.Usuario).ToListAsync();
        }

        public async Task<Evento> GetEventoById(int id)
        {
            return await _context.Eventos.Include(e => e.Usuario).FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<Evento> AddEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<Evento> UpdateEvento(Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
                return false;

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
