using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class NivelEscolaridade
    {
        public NivelEscolaridade()
        {
            Candidatos = new HashSet<Candidato>();
        }

        public int IdNivelEscolaridade { get; set; }
        public string Escolaridade { get; set; }

        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}
