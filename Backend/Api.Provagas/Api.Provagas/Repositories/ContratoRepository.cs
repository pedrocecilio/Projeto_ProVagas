using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class ContratoRepository : IContratoRepository
    {

        ProVagasContext ctx = new ProVagasContext();


        public void Atualizar(int id, Contrato contratoAtualizado)
        {
            Contrato contratoBuscado = ctx.Contratos.Find(id);

            contratoBuscado.DataInicio = contratoAtualizado.DataInicio;
            contratoBuscado.DataAlertar = contratoAtualizado.DataAlertar;

            ctx.Contratos.Update(contratoBuscado);

            ctx.SaveChanges();
        }

        public Contrato BuscarPorId(int id)
        {
            return ctx.Contratos.FirstOrDefault(i => i.IdContrato == id);
        }

        public void Cadastrar(Contrato novoContrato)
        {
            ctx.Contratos.Add(novoContrato);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Contratos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Contrato> Listar()
        {
            return ctx.Contratos.ToList();
        }
    }
}
