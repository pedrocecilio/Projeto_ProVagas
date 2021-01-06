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

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository;

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_habilidadeRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma habilidade através do ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>A habilidade buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

                if(habilidadeBuscada != null)
                {
                    return Ok(habilidadeBuscada);
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto contendo as informações da nova habilidade</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            try
            {
                _habilidadeRepository.Cadastrar(novaHabilidade);

                return Ok("Habilidade cadastrada com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto contendo as novas informações da habilidade</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

                if(habilidadeBuscada != null)
                {
                    _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

                    return Ok("Informações atualizadas!");
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

                if (habilidadeBuscada != null)
                {
                    _habilidadeRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
