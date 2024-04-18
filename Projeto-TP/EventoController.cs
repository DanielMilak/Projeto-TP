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

                return Ok(eventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult CancelarEvento(int id, Boolean CancelarEvento)
        {
            try
            {
                _servEvento.Cancelar(id, CancelarEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
