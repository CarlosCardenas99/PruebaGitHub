namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class SearchLoteDto
    {
        public int IdLote { get; set; }
        public int CodigoEstado { get; set; }
        public string Vehiculos { get; set; } = null!;
        public int IdConcesion { get; set; }
        public string? NombreConcesion { get; set; }
        public DateTime? FechaAcopio { get; set; }
        public string HoraAcopio { get; set; } = null!;
        public string CantidadSacos { get; set; } = null!;
        public string Transportistas { get; set; } = null!;
        public DateTime? FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public int IdEstadoTipoMaterial { get; set; }
        public string? NombreEstadoTipoMaterial { get; set; }
        public float Tmh { get; set; }
        public float Humedad { get; set; }
        public float Tms { get; set; }
        public string NumeroTickets { get; set; } = null!;
    }
}
