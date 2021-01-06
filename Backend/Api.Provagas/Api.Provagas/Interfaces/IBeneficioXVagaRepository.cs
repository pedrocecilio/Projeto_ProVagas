using Api.Provagas.Domains;
using Api.Provagas.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IBeneficioXVagaRepository : IRepositoryBase<BeneficioXvaga>
    {
        public IEnumerable<VagasViewModels> getallvagas(int id);
    }
}
