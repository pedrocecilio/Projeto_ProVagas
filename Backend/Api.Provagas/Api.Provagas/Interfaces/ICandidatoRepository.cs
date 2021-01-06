using Api.Provagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface ICandidatoRepository : IRepositoryBase<Candidato>
    {

        Candidato Login(string email, string senha);
        bool EmailExist(string email);
    }
}
