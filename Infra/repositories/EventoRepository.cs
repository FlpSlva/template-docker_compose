using Domain.entities;
using Domain.repositories;
using Infra.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DataContext _context;
        public EventoRepository(
            DataContext context)
        {
            _context = context;
        }
        public async Task<List<Evento>> GetAllEventosAync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos;
            

            query = query.AsNoTracking().OrderBy(x => x.DataEvento);

            return await query.ToListAsync();
        }
        public async Task<List<Evento>> GetAllEventosByTemaAync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos;
          

            

            query = query
            .AsNoTracking()
            .OrderBy(x => x.DataEvento)
            .Where(x => x.Tema.ToLower()
                .Contains(tema.ToLower()));

            return await query.ToListAsync();
        }

        public async Task<Evento> GetEventoByIdAync(Guid eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos;
           

            query = query.AsNoTracking().OrderBy(x => x.Id)
            .Where(x => x.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
