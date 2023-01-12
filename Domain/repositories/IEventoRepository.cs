using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.repositories
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllEventosByTemaAync(string tema, bool includePalestrantes);
        Task<List<Evento>> GetAllEventosAync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAync(Guid eventoId, bool includePalestrantes);
    }
}
