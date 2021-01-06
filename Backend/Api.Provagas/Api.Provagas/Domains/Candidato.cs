using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            ExperienciaProfissionals = new HashSet<ExperienciaProfissional>();
            HabilidadeXcandidatos = new HashSet<HabilidadeXcandidato>();
            Inscricaos = new HashSet<Inscricao>();
        }

        public int IdCandidato { get; set; }
        public string NomeCompletoCandidato { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Linkedin { get; set; }
        public byte[] FotoPerfil { get; set; }
        public byte[] Curriculo { get; set; }
        public string NomeGenero { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public string NomeDeficiencia { get; set; }
        public string NomeIdioma { get; set; }
        public string NomeNivel { get; set; }
        public bool CursandoSenai { get; set; }
        public string Curso { get; set; }
        public string TesteDePersonalidade { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdNivelEscolaridade { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual NivelEscolaridade IdNivelEscolaridadeNavigation { get; set; }
        public virtual ICollection<ExperienciaProfissional> ExperienciaProfissionals { get; set; }
        public virtual ICollection<HabilidadeXcandidato> HabilidadeXcandidatos { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
