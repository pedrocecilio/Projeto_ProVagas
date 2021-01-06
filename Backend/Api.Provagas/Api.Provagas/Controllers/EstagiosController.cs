using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Provagas.Controllers
{
    // Resposta em Json da requisição
    [Produces("application/json")]
    // Definindo meu endpoint
    [Route("api/[controller]")]
    // Indicando que meu tipo da requisição vai ser em HTTP API
    [ApiController]

    public class EstagiosController : Controller
    {
        // Crio uma variável para minha interface
        private IEstagioRepository _estagioRepository { get; set; }

        public EstagiosController()
        {
            // Instancio meu repositório na minha variável
            _estagioRepository = new EstagioRepository();
        }

        /// <summary>
        /// Listar os estagios
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estagioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Buscar um estágio pelo ID
        /// </summary>
        /// <param name="id">Id do estágio que será buscado</param>
        /// <returns>Retorna um estágio específico pelo Id</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_estagioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar um novo estágio
        /// </summary>
        /// <param name="novoEstagio">Objeto novoEstagio que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Estagio novoEstagio)
        {
            try
            {
                _estagioRepository.Cadastrar(novoEstagio);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza um estágio
        /// </summary>
        /// <param name="id">Id do estágio que será buscado</param>
        /// <param name="estagioAtualizado">Objeto estagioAtualizado que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estagio estagioAtualizado)
        {
            try
            {
                _estagioRepository.Atualizar(id, estagioAtualizado);
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
        /// Deletar um estágio
        /// </summary>
        /// <param name="id">Id do estágio que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _estagioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}