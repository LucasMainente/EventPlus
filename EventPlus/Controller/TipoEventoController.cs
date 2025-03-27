using EventPlus.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using EventoPlus.Interfaces;

namespace EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {

        private readonly ITipoEventoRepository _tiposEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tiposEventoRepository = tipoEventoRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_tiposEventoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]

        public IActionResult Post(TipoEvento tipoEventos)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tipoEventos);

                return StatusCode(201, tipoEventos);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento EventoBuscado = _tiposEventoRepository.BuscarPorId(id);

                return Ok(EventoBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tipoEvento);

                return StatusCode(204, tipoEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

