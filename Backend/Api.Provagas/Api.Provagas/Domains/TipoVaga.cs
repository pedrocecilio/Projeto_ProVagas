using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class TipoVaga
    {
        public TipoVaga()
        {
            Vagas = new HashSet<Vaga>();
        }

        public int IdTipoVaga { get; set; }
        public string NomeTipoVaga { get; set; }

        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
