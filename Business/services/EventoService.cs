using Business.Interface;
using Domain.entities;
using Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IGeralRepository _geralRepository;
        public EventoService(
            IEventoRepository eventoRepository,
            IGeralRepository geralRepository)
        {
            _eventoRepository = eventoRepository;
            _geralRepository = geralRepository;
        }
        public async Task AddEventos(Evento model)
        {
            try
            {
                _geralRepository.Add<Evento>(model);
                await _geralRepository.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }
        public async Task<Evento> UpdateEvento(Guid eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAync(eventoId, false);
                if (evento == null) throw new Exception("evento não encontrado");

                evento.Local = model.Local;
                evento.Tema = model.Tema;
                evento.DataEvento = model.DataEvento;
                evento.Email = model.Email;
                evento.QtdPessoas = model.QtdPessoas;
                evento.Telefone = model.Telefone;
                evento.ImagemUrl = model.ImagemUrl;


                _geralRepository.Update<Evento>(evento);
                await _geralRepository.SaveChangesAsync();

                return evento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvento(Guid eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAync(eventoId, false);
                if (evento == null) throw new Exception("evento não encontrado");

                _geralRepository.Delete<Evento>(evento);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public async Task<List<Evento>> GetAllEventosAync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Evento>> GetAllEventosByTemaAync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAync(Guid eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAync(eventoId, includePalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
