using Microsoft.EntityFrameworkCore;
using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public Candidato Login(string email, string senha)
        {
            Candidato candidatoBuscado = ctx.Candidato.Include(x => x.IdEnderecoNavigation.IdUsuarioNavigation).
                FirstOrDefault(x => x.IdEnderecoNavigation.IdUsuarioNavigation.Email == email && x.IdEnderecoNavigation.IdUsuarioNavigation.Senha == senha);

            if (candidatoBuscado != null)
            {
                return candidatoBuscado;
            }

            return null;
        }

        public IEnumerable<match> match(int id)
        {
            var habilidade = ctx.HabilidadeXcandidato.Include(c => c.IdHabilidadeNavigation.NomeHabilidade)
                .Include(c => c.IdCandidatoNavigation.IdEnderecoNavigation.Cep)
                .Include(c => c.IdCandidatoNavigation.IdNivelEscolaridadeNavigation.Escolaridade)
                .FirstOrDefault(u => u.IdCandidato == id);

            List<Vaga> vagas = ctx.Vagas
                .Include(v => v.NomeVaga)
                .Include(v => v.IdTipoVagaNavigation.NomeTipoVaga)
                .Include(v => v.IdNivelVagaNavigation.NomeNivelVaga)
                .Include(v => v.Localizacao)
                .Include(v => v.Salario)
                .Include(v => v.IdEmpresaNavigation.NomePorte)
                .ToList();

            List<RequisitoXvaga> req = ctx.RequisitoXvaga
                .Include(v => v.IdRequisitoNavigation.NomeRequisito).ToList();

            List<match> mat = new List<match>();
            var count = 0;

            foreach (var item in vagas)
            {

                if (habilidade.IdCandidatoNavigation.IdEnderecoNavigation.Cep.ToLower() == item.Localizacao.ToLower()) 
                count++;

                foreach (var a in req)
                {
                    if (habilidade.IdHabilidadeNavigation.NomeHabilidade.ToLower() == a.IdRequisitoNavigation.NomeRequisito.ToLower()) 
                    count++;
                }

            }
            return mat;
        }

        public bool EmailExist(string email)
        {
            var acesso = ctx.Usuarios.FirstOrDefault(u => u.Email == email);


            if (acesso != null)
            {
                return true;
            }

            return false;
        }

    }
}
