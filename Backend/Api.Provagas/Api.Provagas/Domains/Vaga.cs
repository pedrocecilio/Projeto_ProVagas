using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            BeneficioXvagas = new HashSet<BeneficioXvaga>();
            Inscricaos = new HashSet<Inscricao>();
            RequisitoXvagas = new HashSet<RequisitoXvaga>();
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? LimiteDeInscricao { get; set; }
        public string Localizacao { get; set; }
        public string Salario { get; set; }
        public bool? AceitaTrabalhoRemoto { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoVaga { get; set; }
        public int? IdNivelVaga { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual NivelVaga IdNivelVagaNavigation { get; set; }
        public virtual TipoVaga IdTipoVagaNavigation { get; set; }
        public virtual ICollection<BeneficioXvaga> BeneficioXvagas { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
        public virtual ICollection<RequisitoXvaga> RequisitoXvagas { get; set; }
    }
}
