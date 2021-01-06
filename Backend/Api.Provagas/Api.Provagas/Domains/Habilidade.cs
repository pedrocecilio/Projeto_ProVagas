using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeXcandidatos = new HashSet<HabilidadeXcandidato>();
        }

        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual ICollection<HabilidadeXcandidato> HabilidadeXcandidatos { get; set; }
    }
}
