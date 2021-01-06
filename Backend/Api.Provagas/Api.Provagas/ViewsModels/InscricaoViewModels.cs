using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.ViewsModels
{
    public class InscricaoViewModels
    {
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? LimiteDeInscricao { get; set; }
        public string Localizacao { get; set; }
        public string Salario { get; set; }
        public bool? AceitaTrabalhoRemoto { get; set; }
        public ICollection<string> Beneficios { get; set; }

        public string Status { get; set; }
        public string NomePorte { get; set; }
        public string nomeFantasia { get; set; }

        public string nomeBeneficio { get; set; }

        public int IdVaga { get; set; }
        public int id { get; set; }

        public DateTime DataInscricao { get; set; }
        public string email { get; set; }

        public string nomecandidato { get; set; }
        public string curso { get; set; }
    }
}
