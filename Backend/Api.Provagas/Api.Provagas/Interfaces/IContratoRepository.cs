using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IContratoRepository 
    {
        List<Contrato> Listar();

        void Cadastrar(Contrato novoContrato);

        void Atualizar(int id, Contrato contratoAtualizado);

        void Deletar(int id);

        Contrato BuscarPorId(int id);
    }
}
