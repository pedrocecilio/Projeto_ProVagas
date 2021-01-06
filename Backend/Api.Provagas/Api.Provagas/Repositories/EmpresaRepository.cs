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
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public Empresa Login (string email, string senha)
        {
            Empresa empresaBuscado = ctx.Empresa.Include (x => x.IdEnderecoNavigation.IdUsuarioNavigation).
              FirstOrDefault(x => x.IdEnderecoNavigation.IdUsuarioNavigation.Email == email && x.IdEnderecoNavigation.IdUsuarioNavigation.Senha == senha);

            if (empresaBuscado != null)
            {
                return empresaBuscado;
            }

            return null;
        }
    }
}
