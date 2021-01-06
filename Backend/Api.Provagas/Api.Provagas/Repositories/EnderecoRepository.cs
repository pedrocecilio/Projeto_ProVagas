using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public int CadastrarEndereco(Endereco endereco)
        {
            using (ProVagasContext ctx = new ProVagasContext())
            {
                ctx.Endereco.Add(endereco);
                ctx.SaveChanges();

                return endereco.IdEndereco;
            }
        }
    }
}
