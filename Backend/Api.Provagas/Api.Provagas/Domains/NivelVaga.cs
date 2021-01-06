using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class NivelVaga
    {
        public NivelVaga()
        {
            Vagas = new HashSet<Vaga>();
        }

        public int IdNivelVaga { get; set; }
        public string NomeNivelVaga { get; set; }

        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
