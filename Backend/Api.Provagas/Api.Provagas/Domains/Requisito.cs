using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Requisito
    {
        public Requisito()
        {
            RequisitoXvagas = new HashSet<RequisitoXvaga>();
        }

        public int IdRequisito { get; set; }
        public string NomeRequisito { get; set; }

        public virtual ICollection<RequisitoXvaga> RequisitoXvagas { get; set; }
    }
}
