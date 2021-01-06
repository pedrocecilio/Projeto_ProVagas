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

namespace ProVagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequisitosController : ControllerBase
    {
        private IRequisitosRepository _requisitosrepository { get; set; }

        public RequisitosController()
        {

            _requisitosrepository = new RequisitosRepository();
        }

        /// <summary>
        /// Lsitar todos os requisitos
        /// </summary>
        /// <returns>Retorna uma lista com os requisitos</returns>
        
        [HttpGet]
        public IEnumerable<Requisito> Get()
        {
            return _requisitosrepository.GetAll();
        }

        /// <summary>
        /// Listar os requisitos pelo Id
        /// </summary>
        /// <param name="id">Id do requisito que será buscado</param>
        /// <returns>Retorna uma lista com os requisitos pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_requisitosrepository.GetById(id) != null)
            {
                return Ok(_requisitosrepository.GetById(id));
            }
            else
            {
                return BadRequest("Requisito não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo requisito
        /// </summary>
        /// <param name="requisito"></param>
        /// <returns>Retorna o cadastro de um novo requisito</returns>

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Requisito requisito)
        {
            try
            {
                _requisitosrepository.Add(requisito);

                return Ok("Um novo requisito foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Requisito não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um requisito pelo Id
        /// </summary>
        /// <param name="id">Id do requisito que será buscado</param>
        /// <param name="requisitocadastrado"></param>
        /// <returns>Retorna um requisito atualizado</returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Requisito requisitocadastrado)
        {

            try
            {
                Requisito UPDATE = new Requisito
                {
                    IdRequisito = id,
                    NomeRequisito = requisitocadastrado.NomeRequisito
                };

                _requisitosrepository.Update(UPDATE);

                return Ok("Requisito foi atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse Requisito");
            }
        }

        /// <summary>
        /// Deletar um requisito pelo Id
        /// </summary>
        /// <param name="id">Id do requisito que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Requisito requisitoBuscado = _requisitosrepository.GetById(id);
                _requisitosrepository.Delete(requisitoBuscado);

                return Ok("Requisito deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse Requisito");
            }
        }
    }
}
