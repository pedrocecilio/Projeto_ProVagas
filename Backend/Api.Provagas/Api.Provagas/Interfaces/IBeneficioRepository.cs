using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IBeneficioRepository
    {
        List<Beneficio> Listar();

        void Cadastrar(Beneficio novoBeneficio);

        void Atualizar(int id, Beneficio beneficioAtualizado);

        void Deletar(int id);

        Beneficio BuscarPorId(int id);
    }
}
