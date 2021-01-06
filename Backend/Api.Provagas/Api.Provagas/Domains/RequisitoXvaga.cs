using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class RequisitoXvaga
    {
        public int IdRequisitoVaga { get; set; }
        public int? IdRequisito { get; set; }
        public int? IdVaga { get; set; }

        public virtual Requisito IdRequisitoNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
