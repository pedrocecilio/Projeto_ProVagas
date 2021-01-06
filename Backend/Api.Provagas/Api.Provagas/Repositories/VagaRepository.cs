using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class VagaRepository : RepositoryBase<Vaga>, IVagaRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public IEnumerable<InscricaoViewModels> getempresa(int id)
        {
            List<Vaga> vagas = ctx.Vagas
                .Include(v => v.IdEmpresaNavigation)
                .Where(v => v.IdEmpresa == id)
                .ToList();

            List<InscricaoViewModels> getemp = new List<InscricaoViewModels>();

            foreach (var item in vagas)
            {
                InscricaoViewModels emp = new InscricaoViewModels
                {
                    IdVaga = item.IdVaga,
                    NomeVaga = item.NomeVaga,
                    DescricaoAtividade = item.DescricaoAtividade,
                    Salario = item.Salario,
                    Localizacao = item.Localizacao,
                    AceitaTrabalhoRemoto = item.AceitaTrabalhoRemoto,
                    nomeFantasia = item.IdEmpresaNavigation.NomeFantasia,
                    NomePorte = item.IdEmpresaNavigation.NomePorte
                };
                getemp.Add(emp);
            }
            return getemp;
        }

        public IEnumerable<InscricaoViewModels> get()
        {
            List<Vaga> vagas = ctx.Vagas
                .Include(v => v.IdEmpresaNavigation)
                .ToList();


            List<InscricaoViewModels> getemp = new List<InscricaoViewModels>();

            foreach (var item in vagas)
            {
                InscricaoViewModels emp = new InscricaoViewModels
                {
                    IdVaga = item.IdVaga,
                    NomeVaga = item.NomeVaga,
                    DescricaoAtividade = item.DescricaoAtividade,
                    Salario = item.Salario,
                    Localizacao = item.Localizacao,
                    AceitaTrabalhoRemoto = item.AceitaTrabalhoRemoto,
                    nomeFantasia = item.IdEmpresaNavigation.NomeFantasia,
                    NomePorte = item.IdEmpresaNavigation.NomePorte
                };
                getemp.Add(emp);
            }
            return getemp;
        }

    }
}
