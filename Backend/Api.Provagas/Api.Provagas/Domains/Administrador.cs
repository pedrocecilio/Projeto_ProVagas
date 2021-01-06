using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Provagas.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public string NomeCompletoAdmin { get; set; }
        public string Nif { get; set; }
        public string UnidadeSenai { get; set; }
        public string Departamento { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
