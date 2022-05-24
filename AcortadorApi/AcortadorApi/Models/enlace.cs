using System;
using System.Collections.Generic;

namespace AcortadorApi.Models
{
    public partial class enlace
    {
        public string Codigo { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Enlace1 { get; set; } = null!;
        public bool Estado { get; set; }
        public int? IdPlataforma { get; set; }
        public int IdFuncionario { get; set; }

        public virtual plataforma? IdPlataformaNavigation { get; set; }
    }
}
