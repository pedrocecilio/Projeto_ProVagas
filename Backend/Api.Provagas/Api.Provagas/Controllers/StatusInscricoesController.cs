using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusInscricoesController : ControllerBase
    {
        private IStatusInscricaoRepository _statusInscricaoRepository;

        public StatusInscricoesController()
        {
            _statusInscricaoRepository = new StatusInscricaoRepository();
        }

        /// <summary>
        /// Lista todos os status de inscrição
        /// </summary>
        /// <returns>Uma lista de status de inscrições e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_statusInscricaoRepository.Listar());
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um status de inscrição através do ID
        /// </summary>
        /// <param name="id">ID do status de inscrição que será buscado</param>
        /// <returns>O status de inscrição buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                StatusInscricao statusInscricaoBuscada = _statusInscricaoRepository.BuscarPorId(id);

                if (statusInscricaoBuscada != null)
                {
                    return Ok(statusInscricaoBuscada);
                }

                return NotFound("Nenhum status de inscrição encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo status de inscrição
        /// </summary>
        /// <param name="novoStatusInscricao">Objeto contendo as informações do novo status de inscrição</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [HttpPost]
        public IActionResult Post(StatusInscricao novoStatusInscricao)
        {
            try
            {
                _statusInscricaoRepository.Cadastrar(novoStatusInscricao);

                return Ok("Status de Inscrição cadastrado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um status de inscrição existente
        /// </summary>
        /// <param name="id">ID do status de inscrição que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                StatusInscricao statusInscricaoBuscada = _statusInscricaoRepository.BuscarPorId(id);

                if (statusInscricaoBuscada != null)
                {
                    _statusInscricaoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum status de incrição encontrado para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
