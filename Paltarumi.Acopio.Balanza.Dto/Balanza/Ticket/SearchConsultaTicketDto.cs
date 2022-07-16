namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class SearchConsultaTicketDto
    {
        public int? IdTicket { get; set; }
        public string CodigoLote { get; set; } = null!;//lote
        public string Numero { get; set; } = null!;
        public DateTimeOffset? FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public string Concesion { get; set; } = null!;//concesion
        public string Proveedor { get; set; } = null!;//proveedor
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public float PesoBrutoCarreta { get; set; }
        public float TaraCarreta { get; set; }
        public float PesoNetoCarreta { get; set; }
        public float PesoNetoTotal { get; set; }
        public string Transportista { get; set; } = null!;//transporte
        public string Placa { get; set; } = null!;
        public string VehiculoMarca { get; set; } = null!;
        public string TipoVehiculo { get; set; } = null!;
        public string VehiculoTara { get; set; } = null!;
        public string Conductor { get; set; } = null!;//conductor
        public string Licencia { get; set; } = null!;
        public string UnidadMedida { get; set; } = null!;
        public string CantidadSacos { get; set; } = null!;
        public float? PorcentajeHumedad { get; set; }
        public string CantidadUnidadMedida { get; set; } = null!;
    }
}
