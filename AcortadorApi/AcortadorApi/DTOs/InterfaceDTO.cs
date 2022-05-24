using System.Collections.Generic;

namespace AcortadorApi.DTOs
{
    public class InterfaceDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string EnlaceTutorial { get; set; } = string.Empty;
        public int Tipo { get; set; }
        public int IdModulo { get; set; }
        public string Icono { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public List<TareaDTO>? Tareas { get; set; }

    }
}
