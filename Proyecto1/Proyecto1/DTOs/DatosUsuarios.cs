using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.DTOs
{
    public class DatosUsuarios
    {
        public long UserId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Sede { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int CargoId { get; set; }
        public int SedeId { get; set; }
        public DateTime ExpiraccionToken { get; set; }


    }
}
