using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEventoService
    {
        Task AddEventos(Evento model);
        Task<Evento> UpdateEvento(Guid eventoId, Evento model);
        Task<bool> DeleteEvento(Guid eventoId);

        Task<List<Evento>> GetAllEventosByTemaAync(string tema, bool includePalestrantes = false);
        Task<List<Evento>> GetAllEventosAync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAync(Guid eventoId, bool includePalestrantes = false);
    }
}
