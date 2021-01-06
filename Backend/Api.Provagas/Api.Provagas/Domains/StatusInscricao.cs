using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class StatusInscricao
    {
        public StatusInscricao()
        {
            Inscricaos = new HashSet<Inscricao>();
        }

        public int IdStatusInscricao { get; set; }
        public string NomeStatus { get; set; }

        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
