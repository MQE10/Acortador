using System.ComponentModel.DataAnnotations.Schema;

namespace AcortadorApi.DTOs
{
    public class FiltroDTO
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistrosPorPagina { get; set; } = 20;


        public long UserId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
