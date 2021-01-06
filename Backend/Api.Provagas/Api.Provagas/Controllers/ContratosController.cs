using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : Controller
    {
       private IContratoRepository _contratoRepository { get; set; }

        public ContratosController()
        {
            _contratoRepository = new ContratoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_contratoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_contratoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post (Contrato novoContrato)
        {
            try
            {
                _contratoRepository.Cadastrar(novoContrato);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Contrato contratoAtualizado)
        {
            try
            {
                _contratoRepository.Atualizar(id, contratoAtualizado);

                return StatusCode(202);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _contratoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }







    }
}
