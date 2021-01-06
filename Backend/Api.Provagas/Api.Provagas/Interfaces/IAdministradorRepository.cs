using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IAdministradorRepository : IRepositoryBase<Administrador>
    {
        Administrador Login(string email, string senha);
    }
}
