using EventoPlus.Interfaces;
using EventPlus.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaRepository _presencaRepository;
        public PresencaController(IPresencaRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        /// <summary>
        /// Endpoint para Listar Presenças
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Inscrever(Cadastrar presença)
        /// </summary>
        /// <param name="novaPresenca"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Presenca novPresenca)
        {
            try
            {
                _presencaRepository.Inscrever(novPresenca);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar por id as presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
            
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// Endpoint para deletar presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Presenca presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }



        /// <summary>
        /// Endpoint para listar suas presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarMinhas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                
                return Ok(_presencaRepository.ListarMinhas(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }
    }
}
