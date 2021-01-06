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
    public class ExperienciasProfissionaisController : ControllerBase
    {

        private IExperienciaProfissional _experienciaProfissional { get; set; }

        public ExperienciasProfissionaisController()
        {

            _experienciaProfissional = new ExperienciaProfissionalRepository();
        }

        /// <summary>
        /// Listar as experiencias profissionais do candidato
        /// </summary>
        /// <returns>Retorna uma lista das experiencias profissionais</returns>
        [HttpGet]
        public IEnumerable<ExperienciaProfissional> Get()
        {
            return _experienciaProfissional.GetAll();
        }

        /// <summary>
        /// Listar as experiencias profissionais do candidato pelo Id
        /// </summary>
        /// <param name="id">Id da experiencia profissional que será buscado</param>
        /// <returns>Retorna uma lista de experiencias profissionais pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_experienciaProfissional.GetById(id) != null)
            {
                return Ok(_experienciaProfissional.GetById(id));
            }
            else
            {
                return BadRequest("Experiencia profissional não encontrada.");
            }
        }

        /// <summary>
        /// Cadastrar uma nova experiencia profissional
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>Retorna o cadastro de uma nova experiencia profissional</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ExperienciaProfissional exp)
        {
            try
            {
                _experienciaProfissional.Add(exp);

                return Ok("Experiencia cadastrada com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Experiencia não cadastrada");
            }

        }

        /// <summary>
        /// Atualizar uma experiencia profissional pelo Id
        /// </summary>
        /// <param name="id">Id da experiencia profissional que será buscado</param>
        /// <param name="experiAtt"></param>
        /// <returns>Retorna uma experiência profissional atualizada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ExperienciaProfissional experiAtt)
        {

            try
            {
                ExperienciaProfissional UPDATE = new ExperienciaProfissional
                {
                    IdExperienciaProfissional = id,
                    NomeExperiencia = experiAtt.NomeExperiencia,
                    NomeEmpresa = experiAtt.NomeEmpresa,
                    Cargo = experiAtt.Cargo,
                    DataInicio = experiAtt.DataInicio,
                    DataFim = experiAtt.DataFim,
                    EmpregoAtual = experiAtt.EmpregoAtual,
                    DescricaoAtividade = experiAtt.DescricaoAtividade,
                    IdCandidato = experiAtt.IdCandidato
                };

                _experienciaProfissional.Update(UPDATE);

                return Ok("Experiencia atualizada com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar essa experiencia");
            }
        }

        /// <summary>
        /// Deletar uma experiencia profissional pelo Id
        /// </summary>
        /// <param name="id">Id da experiencia profissional que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ExperienciaProfissional experienciaBuscado = _experienciaProfissional.GetById(id);
                _experienciaProfissional.Delete(experienciaBuscado);

                return Ok("Experiencia deletada com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar essa experiencia");
            }

        }
    }
}