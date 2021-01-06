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
    public class HabilidadesXCandidatosController : ControllerBase
    {
        private IHabilidadeXcandidatoRepository _habilidadeXCandidatoRepository;

        public HabilidadesXCandidatosController()
        {
            _habilidadeXCandidatoRepository = new HabilidadeXcandidatoRepository();
        }

        /// <summary>
        /// Lista todas as habilidades do candidato
        /// </summary>
        /// <returns>Uma lista de habilidades do candidato</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_habilidadeXCandidatoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma habilidade de um candidato através do ID
        /// </summary>
        /// <param name="id">ID da habilidadeXcandidato que será buscada</param>
        /// <returns>A habilidade buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                HabilidadeXcandidato habilidadeXCandidatoBuscada = _habilidadeXCandidatoRepository.BuscarPorId(id);

                if (habilidadeXCandidatoBuscada != null)
                {
                    return Ok(habilidadeXCandidatoBuscada);
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        ///// <summary>
        ///// Cadastra uma nova habilidadeXcandidato
        ///// </summary>
        ///// <param name="novaHabilidadeXCandidato">Objeto contendo as informações da nova habilidade</param>
        ///// <returns>Um status code Ok e uma mensagem personalizada</returns>
        //[HttpPost]
        //public IActionResult Post(HabilidadeXCandidato novaHabilidadeXCandidato)
        //{
        //    try
        //    {
        //        _habilidadeXCandidatoRepository.Cadastrar(novaHabilidadeXCandidato);

        //        return Ok("Habilidade cadastrada com sucesso!");
        //    }
        //    catch (Exception error)
        //    {
        //        return BadRequest(error);
        //    }
        //}

        /// <summary>
        /// Atualiza uma habilidadeXcandidato existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeXCandidatoAtualizada">Objeto contendo as novas informações da habilidade</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [HttpPatch("{id}")]
        public IActionResult Put(int id, HabilidadeXcandidato habilidadeXCandidatoAtualizada)
        {
            try
            {
                HabilidadeXcandidato habilidadeXCandidatoBuscada = _habilidadeXCandidatoRepository.BuscarPorId(id);

                if (habilidadeXCandidatoBuscada != null)
                {
                    _habilidadeXCandidatoRepository.Atualizar(id, habilidadeXCandidatoAtualizada);

                    return Ok("Informações atualizadas!");
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma habilidadeXcandidato existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                HabilidadeXcandidato habilidadeXCandidatoBuscada = _habilidadeXCandidatoRepository.BuscarPorId(id);

                if (habilidadeXCandidatoBuscada != null)
                {
                    _habilidadeXCandidatoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma habilidade encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
