using Microsoft.EntityFrameworkCore;
using Api.Provagas.Interfaces;
using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Provagas.Contexts;

namespace Api.Provagas.Repositories
{
    public class EstagioRepository : IEstagioRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public void Atualizar(int id, Estagio estagioAtualizado)
        {
            Estagio estagioBuscado = ctx.Estagio.Find(id);

            estagioBuscado.DataInicio = estagioAtualizado.DataInicio;
            estagioBuscado.DataFinal = estagioAtualizado.DataFinal;

            ctx.Estagio.Update(estagioBuscado);

            ctx.SaveChanges();
        }

        public Estagio BuscarPorId(int id)
        {
            return ctx.Estagio.FirstOrDefault(i => i.IdEstagio == id);
        }

        public void Cadastrar(Estagio novoEstagio)
        {
            ctx.Estagio.Add(novoEstagio);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Estagio.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Estagio> Listar()
        {
            return ctx.Estagio.ToList();
        }
    }
}
