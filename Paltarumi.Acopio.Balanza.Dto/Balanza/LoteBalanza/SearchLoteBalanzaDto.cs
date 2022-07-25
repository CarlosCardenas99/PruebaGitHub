namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class SearchLoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public string? Estado { get; set; }
        public string? NombreConcesion { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public string CantidadSacos { get; set; } = null!;
        public DateTimeOffset? FechaIngreso { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string CodigoEstado { get; set; } = null!;
        public string? NombreProveedor { get; set; }
        public string? NombreEstadoTipoMaterial { get; set; }
        public float Tmh { get; set; }
        public float? Humedad { get; set; }
        public float? Tms { get; set; }
        public string NumeroTickets { get; set; } = null!;
    }
}
