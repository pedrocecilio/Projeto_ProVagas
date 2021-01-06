using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Candidatos = new HashSet<Candidato>();
            Empresas = new HashSet<Empresa>();
        }

        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string NomeCidade { get; set; }
        public string NomeEstado { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
