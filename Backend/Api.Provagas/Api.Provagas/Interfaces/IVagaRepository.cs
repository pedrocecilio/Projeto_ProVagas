using Api.Provagas.Domains;
using Api.Provagas.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Interfaces
{
    interface IVagaRepository : IRepositoryBase<Vaga>
    {
        public IEnumerable<InscricaoViewModels> getempresa(int id);

        public IEnumerable<InscricaoViewModels> get();

    }
}
