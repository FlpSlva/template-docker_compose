using Api.ViewModel;
using Business.Interface;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;


        public EventoController(
           IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create([FromBody] CreateEventoTesViewModel model)
        {

            try
            {
                var evento = new Evento()
                {
                    DataEvento = model.DataEvento.AddDays(1),
                    ImagemUrl = model.ImagemUrl,
                    Local = model.Local,
                    Tema = model.Tema,
                    Email = model.Email,
                    QtdPessoas = model.QtdPessoas,
                    Telefone = model.Telefone
                };

                await _eventoService.AddEventos(evento);

                return Ok(evento);

            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar salvar evento. Erro: {e.Message}");
            }
        }

        [HttpGet("/list")]
        public async Task<IActionResult> List()
        {

            try
            {
                var evento = await _eventoService.GetAllEventosAync(false);
                if (evento == null) return NotFound("Evento não encontrado.");
                return Ok(evento);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }
    }
}
