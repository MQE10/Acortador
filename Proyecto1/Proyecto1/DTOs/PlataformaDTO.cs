﻿namespace Proyecto1.DTOs
{
    public class PlataformaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
