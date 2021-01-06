using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Vagas = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string DescricaoEmpresa { get; set; }
        public string NomeParaContato { get; set; }
        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public string NomePorte { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
