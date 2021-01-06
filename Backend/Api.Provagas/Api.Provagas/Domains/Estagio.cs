using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Estagio
    {
        public int IdEstagio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public string NomeStatus { get; set; }
        public int? IdInscricao { get; set; }

        public virtual Inscricao IdInscricaoNavigation { get; set; }
    }
}
