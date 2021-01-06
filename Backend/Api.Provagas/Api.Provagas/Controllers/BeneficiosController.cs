using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;

namespace Api.Provagas.Controllers
{
    // Resposta em Json da requisição
    [Produces("application/json")]
    // Definindo meu endpoint
    [Route("api/[controller]")]
    // Indicando que meu tipo da requisição vai ser em HTTP API
    [ApiController]

    public class BeneficiosController : Controller
    {
        // Crio uma variável para minha interface
        private IBeneficioRepository _beneficioRepository { get; set; }

        public BeneficiosController()
        {
            // Instancio meu repositório na minha variável
            _beneficioRepository = new BeneficioRepository();
        }

        /// <summary>
        /// Listar os benefícios
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_beneficioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Buscar um benefício pelo ID
        /// </summary>
        /// <param name="id">Id do benefício que será buscado</param>
        /// <returns>Retorna um benefício específico pelo Id</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_beneficioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar um novo benefício
        /// </summary>
        /// <param name="novoBeneficio">Objeto novoBeneficio que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Beneficio novoBeneficio)
        {
            try
            {
                _beneficioRepository.Cadastrar(novoBeneficio);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza um benefício
        /// </summary>
        /// <param name="id">Id do benefício que será buscado</param>
        /// <param name="beneficioAtualizado">Objeto beneficioAtualizado que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Beneficio beneficioAtualizado)
        {
            try
            {
                _beneficioRepository.Atualizar(id, beneficioAtualizado);
                // Aceito
                return StatusCode(202);
            }
            catch (Exception erro)
            {
                // Má requisição
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deletar um benefício
        /// </summary>
        /// <param name="id">Id do benefício que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _beneficioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}