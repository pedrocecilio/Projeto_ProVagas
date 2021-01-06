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
    public class AdministradoresController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        private IAdministradorRepository _administradorRepository { get; set; }

        private IEmpresaRepository _empresaRepository { get; set; }

        private ICandidatoRepository _candidatoRepository { get; set; }

        public AdministradoresController()
        {
            _administradorRepository = new AdministradorRepository();

            _empresaRepository = new EmpresaRepository();

            _candidatoRepository = new CandidatoRepository();

            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Listar todos administradores
        /// </summary>
        /// <returns> Listar todos administradores</returns>
        [HttpGet]
        public IEnumerable<Administrador> Get()
        {
            return _administradorRepository.GetAll();
        }

        /// <summary>
        /// Listar todas empresas através dos administradores
        /// </summary>
        /// <returns>Listar todas empresas através dos administradores</returns>
        [HttpGet("Empresa")]
        public IActionResult GetEmpresa()
        {
            return Ok(_empresaRepository.GetAll());
        }

        /// <summary>
        /// Listar todos candidatos através dos administradores
        /// </summary>
        /// <returns>Listar todos candidatos através dos administradores</returns>
        [HttpGet("Candidato")]
        public IActionResult GetCandidato()
        {
            return Ok(_candidatoRepository.GetAll());
        }

        /// <summary>
        /// Listar todos os administradores pelo Id
        /// </summary>
        /// <param name="id">Id do administrador que será buscado</param>
        /// <returns>Retorna uma lista de administrador pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_administradorRepository.GetById(id) != null)
            {
                return Ok(_administradorRepository.GetById(id));
            }
            else
            {
                return BadRequest("Administrador não encontrado.");
            }
        }

        [HttpGet("Usuario/{id}")]
        public IActionResult GetUsuario(int id)
        {
            if(_usuarioRepository.GetById(id) != null)
            {
                return Ok(_usuarioRepository.GetById(id));
            }
            else
            {
                return BadRequest("Usuario não Encontrado");
            }
        }

        /// <summary>
        /// Listar os candidatos pelo Id através dos administradores
        /// </summary>
        /// <param name="id">Id do cadndaito que será buscado</param>
        /// <returns>Retorna uma lista de candidatos pelo Id</returns>
        [HttpGet("Candidato/{id}")]
        public IActionResult GetCandidato(int id)
        {
            if (_candidatoRepository.GetById(id) != null)
            {
                return Ok(_candidatoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Candidato não encontrado.");
            }
        }

        /// <summary>
        /// Listar as empresas pelo Id através dos administradores
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <returns>Retorna uma lista de empresas pelo Id</returns>
        [HttpGet("Empresa/{id}")]
        public IActionResult GetEmpresa(int id)
        {
            if (_empresaRepository.GetById(id) != null)
            {
                return Ok(_empresaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Empresa não encontrado.");
            }
        }


        /// <summary>
        /// Cadastrar um novo candidato pelo Id através do administrador
        /// </summary>
        /// <param name="cand"></param>
        /// <returns>Retorna o cadastro de um novo candidato pelo Id</returns>
        [HttpPost("Candidato/{id}")]
        public IActionResult Post(Candidato cand)
        {
            try
            {
                _candidatoRepository.Add(cand);

                return Ok("Candidato cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Candidato não cadastrado");
            }

        }

        /// <summary>
        /// Cadastrar um novo administrador
        /// </summary>
        /// <param name="adm"></param>
        /// <returns>Retorna o cadastro de um novo administrador</returns>
        [HttpPost]
        public IActionResult PostAdministrador(Administrador adm)
        {
            try
            {
                _administradorRepository.Add(adm);

                return Ok("Administrador cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Administrador não cadastrado");
            }

        }


        /// <summary>
        /// Cadastrar uma nova empresa através do administrador
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Retorna o cadastro de uma nova empresa</returns>
        [HttpPost("Empresa")]
        public IActionResult PostEmpresa(Empresa emp)
        {
            try
            {
                _empresaRepository.Add(emp);

                return Ok("Empresa cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Empresa não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar o administrador pelo Id
        /// </summary>
        /// <param name="id">Id do administrador que será buscado</param>
        /// <param name="administrador"></param>
        /// <returns>Retorna o administrador atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador administrador)
        {

            try
            {
                Administrador UPDATE = new Administrador
                {
                    IdAdministrador = id,
                    NomeCompletoAdmin = administrador.NomeCompletoAdmin,
                    Nif = administrador.Nif,
                    Departamento = administrador.Departamento,
                    UnidadeSenai = administrador.UnidadeSenai,
                    IdUsuario = administrador.IdUsuario
                };

                _administradorRepository.Update(UPDATE);

                return Ok("Administrador atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse administrador");
            }
        }


        /// <summary>
        /// Atualizar os candidatos pelo Id através do administrador
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <param name="can"></param>
        /// <returns>Retorna o candidato atualizado</returns>
        [HttpPut("Candidato/{id}")]
        public IActionResult PutCandidato(int id, Candidato can)
        {

            try
            {
                Candidato UPDATE = new Candidato
                {
                    IdCandidato = id,
                    NomeCompletoCandidato = can.NomeCompletoCandidato,
                    Cpf = can.Cpf,
                    DataNascimento = can.DataNascimento,
                    Linkedin = can.Linkedin
                };

                _candidatoRepository.Update(UPDATE);

                return Ok("Candidato atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse candidato");
            }
        }

        /// <summary>
        /// Atualizar a empresa pelo Id através do administrador
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <param name="emp"></param>
        /// <returns>Retorna a empresa atualizada</returns>
        [HttpPut("Empresa/{id}")]
        public IActionResult PutEmpresa(int id, Empresa emp)
        {

            try
            {
                Empresa UPDATE = new Empresa
                {
                    IdEmpresa = id,
                    RazaoSocial = emp.RazaoSocial,
                    NomeFantasia = emp.NomeFantasia,
                    NomeParaContato = emp.NomeParaContato,
                    Linkedin = emp.Linkedin,
                    Website = emp.Website,
                    Cnpj = emp.Cnpj,
                    Cnae = emp.Cnae
                };

                _empresaRepository.Update(UPDATE);

                return Ok("Empresa atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse empresa");
            }
        }

        /// <summary>
        /// Deleta um administrador pelo Id
        /// </summary>
        /// <param name="id">Id do administrador que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.GetById(id);
                _administradorRepository.Delete(administradorBuscado);

                return Ok("Administrador deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse administrador");
            }

        }

        /// <summary>
        /// Deletar um candidato pelo Id através do administrador
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("Candidato/{id}")]
        public IActionResult DeleteCandidato(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.GetById(id);
                _candidatoRepository.Delete(candidatoBuscado);

                return Ok("Candidato deletado com sucesso");

            }
            catch (Exception e )
            {
                return BadRequest(e.InnerException.Message);
            }

        }

        /// <summary>
        /// Deletar uma empresa pelo Id através do administrador
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("Empresa/{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.GetById(id);
                _empresaRepository.Delete(empresaBuscada);

                return Ok("Empresa deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar essa empresa");
            }
        }
    }
}