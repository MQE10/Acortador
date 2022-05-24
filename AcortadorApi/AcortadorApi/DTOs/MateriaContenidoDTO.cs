namespace AcortadorApi.DTOs
{
    public class MateriaContenidoDTO
    {
        public short Id { get; set; }
        public string Sigla { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public short? IdDireccionArea { get; set; }
        public short? IdEstado { get; set; }
        public string EstadoNombre { get; set; } = string.Empty!;
        public decimal? Costo { get; set; }
        public short? Creditos { get; set; }
        public short? HorasTeoricasSemanal { get; set; }
        public short? HorasPracticasSemanal { get; set; }
        public short? TotalHoras { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdModeloEstudio { get; set; }
        public string ModeloEstudioNombre { get; set; } = string.Empty!;
        public string? Competencia { get; set; }
        public int? IdTipoMateriaContenido { get; set; }
        public string? UrlPrograma { get; set; }
        public int? CantidadModulo { get; set; }
        public short? GrupoAcademicoId { get; set; }
        public string GrupoAcademicoNombre { get; set; } = string.Empty;
    }
}
