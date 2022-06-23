﻿namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; } // Ruc o Razón Social
        public int? idEstado { get; set; }
        public string? Vehiculos { get; set; }
        public string? NumeroTickets { get; set; }
    }
}
