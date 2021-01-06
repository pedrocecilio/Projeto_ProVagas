using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Contrato
    {
        public int IdContrato { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataAlertar { get; set; }
        public string Candidato { get; set; }
        public string Empresa { get; set; }
    }
}
