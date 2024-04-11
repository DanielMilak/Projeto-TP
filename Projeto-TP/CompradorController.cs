using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        private IServComprador _servComprador;

        public CompradorController(IServComprador servComprador)
        {
            _servComprador = servComprador;
        }

        [HttpPost]
        public ActionResult Inserir(InserirCompradorDTO CompradorDto)
        {
            try
            {
                _servComprador.Inserir(CompradorDto);

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
                var comprador = _servComprador.BuscarTodos();

                return Ok(comprador);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult CancelarComprador(int id, Boolean CompradorEvento)
        {
            try
            {
                _servComprador.Cancelar(id, CompradorEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
