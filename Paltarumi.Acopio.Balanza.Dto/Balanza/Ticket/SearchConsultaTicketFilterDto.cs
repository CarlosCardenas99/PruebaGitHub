namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class SearchConsultaTicketFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }

        public string? CodigoLote { get; set; }
        public string? Proveedor { get; set; }
        public string? Concesion { get; set; }

        public string? Vehiculo { get; set; }
        public bool VehiculoVacio { get; set; }

        public string? Conductor { get; set; }
        public bool ConductorVacio { get; set; }
        
        public string? Transporte { get; set; }
        public bool TransporteVacio { get; set; }

        public string? GuiaRemisionTransportista { get; set; }
        public bool GuiaRemisionTransportistaVacio { get; set; }

        public string? GuiaRemisionRemitente { get; set; }
        public bool GuiaRemisionRemitenteVacio { get; set; }

        public int TaraInicial { get; set; }
        public int TaraFinal { get; set; }

        public int? idEstado { get; set; }
        public bool Activo { get; set; }
    }
}
