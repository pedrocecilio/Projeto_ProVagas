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
    public class BeneficioXVagaRepository : RepositoryBase<BeneficioXvaga> , IBeneficioXVagaRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public IEnumerable<VagasViewModels> getallvagas(int id)
        {
            List<BeneficioXvaga> vagas = ctx.BeneficioXvaga
                .Include(bv => bv.IdVagaNavigation)
                .Include(bv => bv.IdVagaNavigation.IdEmpresaNavigation)
                .Include(bv => bv.IdBeneficioNavigation)
                .Where(bv => bv.IdVaga == id)
                .ToList();

            List<VagasViewModels> getemp = new List<VagasViewModels>();

            foreach (var item in vagas)
            {
                VagasViewModels emp = new VagasViewModels
                {
                    NomeVaga = item.IdVagaNavigation.NomeVaga,
                    DescricaoAtividade = item.IdVagaNavigation.DescricaoAtividade,
                    DescricaoEmpresa = item.IdVagaNavigation.IdEmpresaNavigation.DescricaoEmpresa,
                    Salario = item.IdVagaNavigation.Salario,
                    Localizacao = item.IdVagaNavigation.Localizacao,
                    AceitaTrabalhoRemoto = item.IdVagaNavigation.AceitaTrabalhoRemoto,
                    NomeFantasia = item.IdVagaNavigation.IdEmpresaNavigation.NomeFantasia,
                    NomePorte = item.IdVagaNavigation.IdEmpresaNavigation.NomePorte,
                    NomeBeneficio = item.IdBeneficioNavigation.NomeBeneficio
                };
                getemp.Add(emp);
            }
            return getemp;

        }

    }
}
