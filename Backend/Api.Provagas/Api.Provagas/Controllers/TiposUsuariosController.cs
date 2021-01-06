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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipouserrepository { get; set; }

        public TiposUsuariosController()
        {

            _tipouserrepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns>Retorna uma lista com os tipos de usuario</returns>
        [HttpGet]
        public IEnumerable<TipoUsuario> Get()
        {
            return _tipouserrepository.GetAll();
        }

        /// <summary>
        /// Listar os tipos de usuario pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>Retorna uma lista de tipos de usuario pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_tipouserrepository.GetById(id) != null)
            {
                return Ok(_tipouserrepository.GetById(id));
            }
            else
            {
                return BadRequest("Tipo de Usuario não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo tipo de usuario
        /// </summary>
        /// <param name="tipouser"></param>
        /// <returns>Retorna o cadastro de um novo tipo de usuario</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario tipouser)
        {
            try
            {
                _tipouserrepository.Add(tipouser);

                return Ok("Um novo tipo de usuario foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Tipo usuario não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um tipo de usuario pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <param name="tipoUsercadastrado"></param>
        /// <returns>Retorna o tipo de usuario atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsercadastrado)
        {

            try
            {
                TipoUsuario UPDATE = new TipoUsuario
                {
                    IdTipoUsuario = id,
                    Usuarios = tipoUsercadastrado.Usuarios
                };

                _tipouserrepository.Update(UPDATE);

                return Ok("Tipo de usuario foi atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse tipo de usuario");
            }
        }

        /// <summary>
        /// Deletar um tipo de usuario pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoUsuario tipobuscado = _tipouserrepository.GetById(id);
                _tipouserrepository.Delete(tipobuscado);

                return Ok("Tipo usuario deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse tipo de usuario");
            }
        }
    }
}
