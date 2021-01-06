using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;

namespace ProVagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosXVagasController : ControllerBase
    {
        private IRequisitoXVagarepository _requisitosxvagarepository { get; set; }

        public RequisitosXVagasController()
        {

            _requisitosxvagarepository = new RequisitoXVagaRepository();
        }


        /// <summary>
        /// Listar os requisitos e as vagas
        /// </summary>
        /// <returns>Retorna uma lista com os requisitos e as vagas</returns>
        [HttpGet]
        public IEnumerable<RequisitoXvaga> Get()
        {
            return _requisitosxvagarepository.GetAll();
        }

        /// <summary>
        /// Listar os requisitos e vagas pelo Id
        /// </summary>
        /// <param name="id">Id do requisitoXvaga que será buscado</param>
        /// <returns>Retorna uma lista com os requisitosXvagas pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_requisitosxvagarepository.GetById(id) != null)
            {
                return Ok(_requisitosxvagarepository.GetById(id));
            }
            else
            {
                return BadRequest("RequisitoXvaga não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo requisitoXvaga
        /// </summary>
        /// <param name="requisitoxvaga"></param>
        /// <returns>Retorna o cadastro de um novo requisitoXvaga</returns>
        [HttpPost]
        public IActionResult Post(RequisitoXvaga requisitoxvaga)
        {
            try
            {
                _requisitosxvagarepository.Add(requisitoxvaga);

                return Ok("Um novo requisitoXVaga foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("requisitoXVaga não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um requisitoXvaga pelo Id
        /// </summary>
        /// <param name="id">Id do requisitoXvaga que será buscado</param>
        /// <param name="requisitoxvagaCadastrado"></param>
        /// <returns>Retorna o requisitoXvaga atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, RequisitoXvaga requisitoxvagaCadastrado)
        {

            try
            {
                RequisitoXvaga UPDATE = new RequisitoXvaga
                {
                    IdRequisitoVaga = id,
                    IdRequisitoNavigation = requisitoxvagaCadastrado.IdRequisitoNavigation,
                    IdVagaNavigation = requisitoxvagaCadastrado.IdVagaNavigation
                };

                _requisitosxvagarepository.Update(UPDATE);

                return Ok("RequisitoXVaga foi atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse RequisitoXVaga");
            }
        }

        /// <summary>
        /// Deletar um requisitoXvaga pelo Id
        /// </summary>
        /// <param name="id">Id do requisitoXvaga que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                RequisitoXvaga RequisitoXVagaBuscado = _requisitosxvagarepository.GetById(id);
                _requisitosxvagarepository.Delete(RequisitoXVagaBuscado);

                return Ok("requisitoXVaga deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse requisitoXVaga");
            }
        }
    }
}
