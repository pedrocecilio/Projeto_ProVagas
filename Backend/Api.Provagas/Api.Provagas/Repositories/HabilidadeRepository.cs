using Microsoft.EntityFrameworkCore;
using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if(habilidadeBuscada != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades
                .Include(h => h.NomeHabilidade)
                .Include(h => h.HabilidadeXcandidatos)
                .FirstOrDefault(h => h.IdHabilidade == id);

            if(habilidadeBuscada != null)
            {
                return habilidadeBuscada;
            }

            return null;
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Habilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
