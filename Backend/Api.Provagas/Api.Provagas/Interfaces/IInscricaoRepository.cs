using Api.Provagas.Domains;
using Api.Provagas.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    /// <summary>
    /// Interface responsável pelo InscricaoRepository
    /// </summary>
    interface IInscricaoRepository
    {
        /// <summary>
        /// Lista todas as inscrições
        /// </summary>
        /// <returns>Uma lista de inscrições</returns>
        List<Inscricao> Listar();

        /// <summary>
        /// Busca uma inscrição através do Id
        /// </summary>
        /// <param name="id">Id da inscrição que será buscada</param>
        /// <returns>Uma inscrição buscada</returns>
        Inscricao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova inscrição
        /// </summary>
        /// <param name="novaInscricao">Objeto contendo as informações da nova inscrição</param>
        void Cadastrar(Inscricao novaInscricao);

        /// <summary>
        /// Atualiza uma inscrição
        /// </summary>
        /// <param name="id">Id da inscrição que será atualizada</param>
        /// <param name="inscricaoAtualizada">Objeto com as informações atualizadas</param>
        void Atualizar(int id, Inscricao inscricaoAtualizada);

        /// <summary>
        /// Deleta uma incrição existente
        /// </summary>
        /// <param name="id">Id da inscrição que será deletada</param>
        void Deletar(int id);
        IEnumerable<InscricaoViewModels> GetInscricoesByid(int id);

        public bool confeinscricao(int iduser, int idvaga);

        public IEnumerable<InscricaoViewModels> Getisncricaobyempresa(int id);

    }
}
