using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;
using Api.Provagas.ViewsModels;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository { get; set; }
        private IInscricaoRepository _inscricaoRepository { get; set; }

        public EmpresasController()
        {

            _empresaRepository = new EmpresaRepository();
            _inscricaoRepository = new InscricaoRepository();
        }


        /// <summary>
        /// Listar os empresa
        /// </summary>
        /// <returns>Lista com todos os empresa</returns>
       
        [HttpGet]
        public IEnumerable<Empresa> Get()
        {
            return _empresaRepository.GetAll();
        }

        [HttpGet("list/{id}")]
        public IEnumerable<InscricaoViewModels> Getisncricaobyempresa(int id)
        {
            return _inscricaoRepository.Getisncricaobyempresa(id);
        }

        /// <summary>
        /// Buscar empresa por id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_empresaRepository.GetById(id) != null)
            {
                return Ok(_empresaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Empresa não encontrados.");
            }
        }

        
        /// <summary>
        /// Cadastrar um novo candidato
        /// </summary>
        [HttpPost]
        public IActionResult Post(Empresa empre)
        {
            Console.WriteLine(empre);
            try
            {
                _empresaRepository.Add(empre);

                return Ok("Empresa cadastrada com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível cadastrar essa empresa!");
            }

        }

        /// <summary>
        /// Atualizar candidato
        /// </summary>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Empresa empresaatt)
        {

            try
            {
                Empresa UPDATE = new Empresa
                {
                    IdEmpresa = id,
                    RazaoSocial = empresaatt.RazaoSocial,
                    NomeFantasia = empresaatt.RazaoSocial,
                    NomeParaContato = empresaatt.NomeParaContato,
                    Linkedin = empresaatt.Linkedin,
                    Website = empresaatt.Website,
                    Cnpj = empresaatt.Cnpj,
                    Cnae = empresaatt.Cnae
                };

                _empresaRepository.Update(UPDATE);

                return Ok("Empresa atualizados com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar o empresa");
            }
        }

        /*Deletar Tipo de vaga*/

        /// <summary>
        /// Deletar candidato
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.GetById(id);
                _empresaRepository.Delete(empresaBuscada);

                return Ok("Empresa deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar o Empresa");
            }

        }
    }
}