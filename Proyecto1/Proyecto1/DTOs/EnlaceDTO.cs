using System.ComponentModel.DataAnnotations;

namespace Proyecto1.DTOs
{
    public class EnlaceDTO
    {
        [Required(ErrorMessage = "El Codigo es Obligatorio")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Solo se permiten Letras y numeros")]
        public string cod { get; set; } = null!;
        [Required(ErrorMessage = "El Titulo es Obligatorio")]
        public string tit { get; set; } = null!;
        [Required(ErrorMessage = "La descripcion es Necesario")]
        public string? desc { get; set; }
        [Required(ErrorMessage = "El Enlace es Obligatorio")]
        public string enlace { get; set; } = null!;
        public bool estado { get; set; }
        public int? idplataforma { get; set; }
        public string? nombreplataforma { get; set; }
        public int idfuncionario { get; set; }

    }
}
