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
    public class NiveisEscolaridadesController : ControllerBase
    {

        private INivelEscolaridadeRepository _nivelescolaridaderepository { get; set; }

        public NiveisEscolaridadesController()
        {

            _nivelescolaridaderepository = new NivelEscolaridadeRepository();
        }

        /// <summary>
        /// Listar todos os niveis de escolaridade
        /// </summary>
        /// <returns>Retorna uma lista com os niveis de escolaridade</returns>
        [HttpGet]
        public IEnumerable<NivelEscolaridade> Get()
        {
            return _nivelescolaridaderepository.GetAll();
        }

        /// <summary>
        /// Listar uma lista de niveis de escolaridade pelo Id
        /// </summary>
        /// <param name="id">Id dos niveis de escolaridade que será buscado</param>
        /// <returns>Retorna uma lista de niveis de escolaridade pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_nivelescolaridaderepository.GetById(id) != null)
            {
                return Ok(_nivelescolaridaderepository.GetById(id));
            }
            else
            {
                return BadRequest("Nivel de escolaridade não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo nivel de escolaridade
        /// </summary>
        /// <param name="nivel"></param>
        /// <returns>Retorna o cadastro de um novo nivel de escolaridade</returns>
        [HttpPost]
        public IActionResult Post(NivelEscolaridade nivel)
        {
            try
            {
                _nivelescolaridaderepository.Add(nivel);

                return Ok("Nivel de escolaridade cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Nivel não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um nivel de escolaridade pelo Id
        /// </summary>
        /// <param name="id">Id dos niveis de escolaridade que será buscado</param>
        /// <param name="nivelcadastrado"></param>
        /// <returns>Retorna um nivel de escolaridade atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, NivelEscolaridade nivelcadastrado)
        {

            try
            {
                NivelEscolaridade UPDATE = new NivelEscolaridade
                {
                    IdNivelEscolaridade = id,
                    Escolaridade = nivelcadastrado.Escolaridade
                };

                _nivelescolaridaderepository.Update(UPDATE);

                return Ok("Nivel de escolaridade atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse nivel de escolaridade");
            }
        }

        /// <summary>
        /// Deletar um nivel de escolaridade pelo Id
        /// </summary>
        /// <param name="id">Id dos niveis de escolaridade que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                NivelEscolaridade nivelbuscado = _nivelescolaridaderepository.GetById(id);
                _nivelescolaridaderepository.Delete(nivelbuscado);

                return Ok("Nivel de escolaridade deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse nivel de escolaridade");
            }

        }
    }
}
