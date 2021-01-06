using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            BeneficioXvagas = new HashSet<BeneficioXvaga>();
        }

        public int IdBeneficio { get; set; }
        public string NomeBeneficio { get; set; }

        public virtual ICollection<BeneficioXvaga> BeneficioXvagas { get; set; }
    }
}
