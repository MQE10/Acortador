using System;
using System.Collections.Generic;

namespace AcortadorApi.Models
{
    public partial class plataforma
    {
        public plataforma()
        {
            enlace = new HashSet<enlace>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<enlace> enlace { get; set; }
    }
}
