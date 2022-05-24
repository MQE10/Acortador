using AcortadorApi.Models;

namespace AcortadorApi.DTOs
{
    public class PlataformaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string? descripcion { get; set; }
        public bool estado { get; set; }
    }
    public static partial class Mapper
    {

        public static List<PlataformaDTO> Map(this List<plataforma> source)
        {
            var items = new List<PlataformaDTO>();

            source.ForEach(value => { items.Add(value.Map()); });

            return items;
        }
        public static PlataformaDTO Map(this plataforma source)
        {
            return new PlataformaDTO
            {
                id = source.Id,
                nombre = source.Nombre,
                descripcion = source.Descripcion,
                estado = source.Estado,
            };
        }

    }
}
