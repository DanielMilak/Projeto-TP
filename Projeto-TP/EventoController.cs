using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IServEvento _servEvento;

        public EventoController(IServEvento servEvento)
        {
            _servEvento = servEvento;
        }

        [HttpPost]
        public ActionResult Inserir(InserirEventoDTO inserirDto)
        {
            try
            {
                _servEvento.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var eventos = _servEvento.BuscarTodos();

                var eventoEnxuta = eventos.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome
                    }).ToList();

                return Ok(eventoEnxuta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
