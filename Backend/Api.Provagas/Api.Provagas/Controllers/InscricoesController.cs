using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InscricoesController : ControllerBase
    {
        private IInscricaoRepository _inscricaoRepository;

        public InscricoesController()
        {
            _inscricaoRepository = new InscricaoRepository();
        }

        /// <summary>
        /// Lista todas as inscrições
        /// </summary>
        /// <returns>Uma lista de inscrições e um status code 200 - Ok</returns>

        //[Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_inscricaoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("varinscricao/{idVaga}")]
        public bool verinscricao(int idVaga)
        {
            var id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return _inscricaoRepository.confeinscricao(id, idVaga);
        }

        /// <summary>
        /// Busca uma inscrição através do ID
        /// </summary>
        /// <param name="id">ID da inscrição que será buscada</param>
        /// <returns>A inscrição buscada e um status code 200 - Ok</returns>
        //[Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Inscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                if (inscricaoBuscada != null)
                {
                    return Ok(inscricaoBuscada);
                }

                return NotFound("Nenhuma inscrição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova inscrição
        /// </summary>
        /// <param name="novaInscricao">Objeto contendo as informações da nova inscrição</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post (Inscricao novaInscricao)
        {
            try
            {
                _inscricaoRepository.Cadastrar(novaInscricao);

                return Ok("Inscrição realizada com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma inscrição existente
        /// </summary>
        /// <param name="id">ID da inscrição que será atualizada</param>
        /// <param name="inscricaoAtualizada">Objeto com as informações atualizadas da inscrição</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        //[Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Inscricao inscricaoAtualizada)
        {
            try
            {
                Inscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                if(inscricaoBuscada != null)
                {
                    _inscricaoRepository.Atualizar(id, inscricaoAtualizada);

                    return Ok("Inscrição atualizada!");
                }

                return NotFound("Nenhuma inscrição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma inscrição existente
        /// </summary>
        /// <param name="id">ID da inscrição que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Inscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                if (inscricaoBuscada != null)
                {
                    _inscricaoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma incrição encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
