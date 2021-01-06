using Microsoft.EntityFrameworkCore;
using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class HabilidadeXcandidatoRepository : IHabilidadeXcandidatoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, HabilidadeXcandidato habilidadeXCandidatoAtualizada)
        {
            HabilidadeXcandidato habilidadeXCandidatoBuscado = ctx.HabilidadeXcandidato.Find(id);

            if(habilidadeXCandidatoBuscado != null)
            {
                habilidadeXCandidatoBuscado.IdHabilidade = habilidadeXCandidatoAtualizada.IdHabilidade;
            }

            if(habilidadeXCandidatoBuscado != null)
            {
                habilidadeXCandidatoBuscado.IdCandidato = habilidadeXCandidatoAtualizada.IdCandidato;
            }

            ctx.HabilidadeXcandidato.Update(habilidadeXCandidatoBuscado);

            ctx.SaveChanges();
        }

        public HabilidadeXcandidato BuscarPorId(int id)
        {
            HabilidadeXcandidato habilidadeXCandidatoBuscado = ctx.HabilidadeXcandidato
                .Include(x => x.IdHabilidadeNavigation)
                .Include(x => x.IdCandidatoNavigation)
                .FirstOrDefault(x => x.IdHabilidadeCandidato == id);

            if(habilidadeXCandidatoBuscado != null)
            {
                return habilidadeXCandidatoBuscado;
            }

            return null;
        }

        public void Cadastrar(HabilidadeXcandidato novaHabilidadeXCandidato)
        {
            ctx.HabilidadeXcandidato.Add(novaHabilidadeXCandidato);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.HabilidadeXcandidato.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<HabilidadeXcandidato> Listar()
        {
            return ctx.HabilidadeXcandidato
                .Include(x => x.IdHabilidadeNavigation)
                .Include(x => x.IdCandidatoNavigation)
                .ToList();
        }
    }
}
