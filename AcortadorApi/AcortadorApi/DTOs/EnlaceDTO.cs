using AcortadorApi.Models;
using System.ComponentModel.DataAnnotations;

namespace AcortadorApi.DTOs
{
    public class EnlaceDTO
    {
        [Required(ErrorMessage = "El Codigo es Obligatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Solo se permiten Letras y numeros")]
        public string cod { get; set; } = null!;
        public string tit { get; set; } = null!;
        public string? desc { get; set; }
        public string enlace { get; set; } = null!;
        public bool estado { get; set; }
        public int? idplataforma { get; set; }
        public string? nombreplataforma { get; set; }
        public int idfuncionario { get; set; }

    }
    public static partial class Mapper
    {
        public static List<EnlaceDTO> Map(this List<enlace> source)
        {
            var items = new List<EnlaceDTO>();

            source.ForEach(value => {items.Add(value.Map()); });

            return items;
        }
        public static EnlaceDTO Map(this enlace source)
        {
            return new EnlaceDTO
            {
                cod = source.Codigo,
                tit = source.Titulo,
                desc = source.Descripcion,
                enlace = source.Enlace1,
                estado = source.Estado,
                idplataforma = source.IdPlataforma,
                idfuncionario = source.IdFuncionario,
                nombreplataforma = source.IdPlataformaNavigation?.Nombre
            };
        }

    }
}
