using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IHabilidadeXcandidatoRepository
    {
        List<HabilidadeXcandidato> Listar();

        HabilidadeXcandidato BuscarPorId(int id);

        void Cadastrar(HabilidadeXcandidato novaHabilidadeXCandidato);

        void Atualizar(int id, HabilidadeXcandidato habilidadeXCandidatoAtualizada);

        void Deletar(int id);
    }
}
