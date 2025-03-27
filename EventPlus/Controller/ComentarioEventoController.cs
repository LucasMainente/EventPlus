using EventoPlus.Interfaces;
using EventoPlus.Repositories;
using EventPlus.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventosRepository _feedbackRepository;

        public ComentarioEventoController(IComentarioEventosRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;

        }

        /// <summary>
        /// Endpoint para cadastrar Feedbackss
        /// </summary>
        /// <param name="novoComentario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento novoFeedback)
        {
            try
            {
                _feedbackRepository.Cadastrar(novoFeedback);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para listar Feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_feedbackRepository.Listar(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para deletar Feedbacks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _feedbackRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Endpoint para buscar Feedbacks por Id dos usuarios
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IdEvento"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorIdUsuario/{IdUsuario},{IdEvento}")]
        public IActionResult GetById(Guid IdUsuario, Guid IdEvento)
        {
            try
            {
                ComentarioEvento novoFeedback = _feedbackRepository.BuscarPorIdUsuario(IdUsuario, IdEvento);
                return Ok(novoFeedback);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}

