namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class SearchTicketDto
    {
        public int? IdTicket { get; set; }
        public string Codigo { get; set; } = null!;//lote
        public string Numero { get; set; } = null!;
        public DateTime? FechaIngreso { get; set; }
        public string HoraIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        public string Concesion { get; set; } = null!;//concesion
        public string Proveedor { get; set; } = null!;//proveedor
        public string Grr { get; set; }
        public string Grt { get; set; }
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public string Transportista { get; set; } = null!;//transporte
        public string Placa { get; set; }
        public string VehiculoMarca { get; set; }
        public string TipoVehiculo { get; set; }
        public string VehiculoTara { get; set; }
        public string Conductor { get; set; } = null!;//conductor
        public string Licencia { get; set; } = null!;
        public string UnidadMedida { get; set; }
        public string CantidadSacos { get; set; } = null!;
        public string PorcentajeHumedad { get; set; }
        public string CantidadUnidadMedida { get; set; }

    }
}
