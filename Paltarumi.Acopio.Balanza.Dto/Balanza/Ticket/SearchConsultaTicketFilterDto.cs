﻿namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class SearchConsultaTicketFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }//listo
        public DateTimeOffset? FechaHasta { get; set; }//listo
        public string? CodigoLote { get; set; }//lote codigo  listo
        public string? Proveedor { get; set; } //ruc - razon social   listp
        public string? Concesion { get; set; }//codigo unico - nombre listo
        public string? Vehiculo { get; set; }//placa-licencia  
        public string? Conductor { get; set; }//nombre-licencia
        public int TaraVehiculo { get; set; } //tara
        public string? GuiaRemisionTransportista { get; set; }//-grt
        public string? GuiaRemisionRemitente { get; set; }//-grr
        public bool Activo { get; set; }
    }
}
