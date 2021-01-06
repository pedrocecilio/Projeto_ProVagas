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
    public class EnderecoController : ControllerBase
    {

        private IEnderecoRepository _enderecorepository { get; set; }

        public EnderecoController()
        {

            _enderecorepository = new EnderecoRepository();
        }

        /// <summary>
        /// Listar todos os endereços 
        /// </summary>
        /// <returns>Retorna uma lista com os endereços</returns>
        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return _enderecorepository.GetAll();
        }

        /// <summary>
        /// Listar endereços pelo Id
        /// </summary>
        /// <param name="id">Id do endereço que será buscado</param>
        /// <returns>Retorna uma lista de endereços pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_enderecorepository.GetById(id) != null)
            {
                return Ok(_enderecorepository.GetById(id));
            }
            else
            {
                return BadRequest("Endereço não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo endereço
        /// </summary>
        /// <param name="ende"></param>
        /// <returns>Retorna o cadastro de um novo endereço</returns>
        [HttpPost]
        public IActionResult Post(Endereco ende)
        {
            EnderecoRepository repository = new EnderecoRepository();
            try
            {
                return Ok(repository.CadastrarEndereco(ende));
            }
            catch (Exception)
            {

                return BadRequest("Endereco não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um endereço pelo Id
        /// </summary>
        /// <param name="id">Id do endereço que será buscado</param>
        /// <param name="enderecoatt"></param>
        /// <returns>Retorna o endereço atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Endereco enderecoatt)
        {

            try
            {
                Endereco UPDATE = new Endereco
                {
                    IdEndereco = id,
                    Rua = enderecoatt.Rua,
                    Numero = enderecoatt.Numero,
                    Bairro = enderecoatt.Bairro,
                    Complemento = enderecoatt.Complemento,
                    Cep = enderecoatt.Cep,
                    NomeEstado = enderecoatt.NomeEstado,
                    NomeCidade = enderecoatt.NomeCidade,
                    IdUsuario = enderecoatt.IdUsuario
                };

                _enderecorepository.Update(UPDATE);

                return Ok("Endereco atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse endereco");
            }
        }

        /// <summary>
        /// Deletar um endereço pelo Id
        /// </summary>
        /// <param name="id">Id do endereço que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Endereco enderecoBuscado = _enderecorepository.GetById(id);
                _enderecorepository.Delete(enderecoBuscado);

                return Ok("Endereco deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse endereco");
            }

        }
    }
}