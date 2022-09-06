namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class SearchLoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public string? LoteEstado { get; set; }
        public string IdLoteEstado { get; set; } = null!;
        public string? NombreConcesion { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public int CantidadSacos { get; set; }
        public DateTimeOffset? FechaIngreso { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string? NombreProveedor { get; set; }
        public string? NombreEstadoTipoMaterial { get; set; }
        public decimal Tmh { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? Tms { get; set; }
        public string NumeroTickets { get; set; } = null!;
    }
}
