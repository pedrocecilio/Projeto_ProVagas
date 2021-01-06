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
using Api.Provagas.ViewsModels;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //
    public class VagasController : ControllerBase
    {
        private IVagaRepository _vagaRepository { get; set; }

        public VagasController()
        {

            _vagaRepository = new VagaRepository();
        }

        /// <summary>
        /// Listar todas as vagas
        /// </summary>
        /// <returns>Lista com todas as vagas</returns>
        [HttpGet]
        public IEnumerable<InscricaoViewModels> Get()
        {
            return _vagaRepository.get();
        }
        [HttpGet("Empresa/{id}")]
        public IEnumerable<InscricaoViewModels> vagasemp(int id)
        {

            return _vagaRepository.getempresa(id);
        }

        /// <summary>
        /// Buscar uma vaga por id
        /// </summary>
        /// <param name="id">Id da vaga a ser buscada</param>
        /// <returns>Vaga buscada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_vagaRepository.GetById(id) != null)
            {
                return Ok(_vagaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Vaga não encontrada.");
            }
        }

        /// <summary>
        /// Cadastrar uma nova vaga
        /// </summary>
        /// <param name="vaga">Nova vaga</param>

        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Vaga vaga)
        {
            try
            {
                _vagaRepository.Add(vaga);

                return Ok("Vaga cadastrada com sucesso!");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível cadastrar a vaga!");
            }

        }

        /// <summary>
        /// Atualizar dados da vaga
        /// </summary>
        /// <param name="id">Id da vaga que será atualizada</param>
        /// <param name="novaVaga">Dados da atualizados da vaga</param>

        //[Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Vaga novaVaga)
        {

            try
            {
                Vaga UPDATE = new Vaga
                {
                    IdVaga = id,
                    NomeVaga = novaVaga.NomeVaga,
                    DescricaoAtividade = novaVaga.DescricaoAtividade,
                    DataInicio = novaVaga.DataInicio,
                    DataFinal = novaVaga.DataFinal,
                    IdEmpresa = novaVaga.IdEmpresa,
                    Localizacao = novaVaga.Localizacao,
                    Salario = novaVaga.Salario,
                    RequisitoXvagas = novaVaga.RequisitoXvagas,
                    BeneficioXvagas = novaVaga.BeneficioXvagas,
                    IdTipoVaga = novaVaga.IdTipoVaga,
                    
                };

                _vagaRepository.Update(UPDATE);

                return Ok("Dados da vaga atualizados com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar os dados da vaga");
            }
        }

        /// <summary>
        /// Deletar uma vaga
        /// </summary>
        /// <param name="id">Id da vaga que será deletada</param>

        //[Authorize(Roles = "2")]
        //[Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.GetById(id);
                _vagaRepository.Delete(vagaBuscada);

                return Ok("Vaga deletada com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esta vaga");
            }

        }
    }
}
