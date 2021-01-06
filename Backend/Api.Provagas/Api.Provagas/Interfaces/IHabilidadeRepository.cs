using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();

        Habilidade BuscarPorId(int id);

        void Cadastrar(Habilidade novaHabilidade);

        void Deletar(int id);

        void Atualizar(int id, Habilidade habilidadeAtualizada);
    }
}
