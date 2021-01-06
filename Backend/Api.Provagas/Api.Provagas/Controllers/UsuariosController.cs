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
    //[Authorize]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuariorepository { get; set; }

        public UsuariosController()
        {

            _usuariorepository = new UsuarioRepository();
        }

        /// <summary>
        /// Listar todos os usuarios
        /// </summary>
        /// <returns>Retorna uma lista com os usuarios</returns>
        //[Authorize(Roles = "3")]
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _usuariorepository.GetAll();
        }

        /// <summary>
        /// Listar todos os usuarios pelo Id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Retorna uma lista de usuarios pelo Id</returns>

        //[Authorize(Roles = "3")]
        [HttpGet("Usuarios/{id}")]
        public IActionResult Get(int id)
        {
            if (_usuariorepository.GetById(id) != null)
            {
                return Ok(_usuariorepository.GetById(id));
            }
            else
            {
                return BadRequest("Usuario não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna o cadastro de um novo usuario</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuariorepository.Add(usuario);

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Usuario não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um usuario pelo Id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns>Retorna o usuario atualizado</returns>
       
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {

            try
            {
                Usuario UPDATE = new Usuario
                {
                    IdUsuario = id,
                    Email = usuarioAtualizado.Email,
                    Telefone = usuarioAtualizado.Telefone,
                    Senha = usuarioAtualizado.Senha,
                    IdTipoUsuario = 3
                };

                _usuariorepository.Update(UPDATE);

                return Ok("Usuario atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse usuario");
            }
        }

        /// <summary>
        /// Deletar um usuario pelo Id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Retorna vazio</returns>

        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Usuario usuariobuscado = _usuariorepository.GetById(id);
                _usuariorepository.Delete(usuariobuscado);

                return Ok("Usuario deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse atualizado");
            }

        }
    }
}