using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class ExperienciaProfissional
    {
        public int IdExperienciaProfissional { get; set; }
        public string NomeExperiencia { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cargo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool? EmpregoAtual { get; set; }
        public string DescricaoAtividade { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
    }
}
