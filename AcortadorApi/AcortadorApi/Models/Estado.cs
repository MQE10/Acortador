using System;
using System.Collections.Generic;

namespace AcortadorApi.Models
{
    public partial class Estado
    {
        public short Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
