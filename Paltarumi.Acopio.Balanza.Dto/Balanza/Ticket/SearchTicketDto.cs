namespace Paltarumi.Acopio.Balanza.Dto.Ticket
{
    public class SearchTicketDto
    {
        public int? IdTicket { get; set; }
        public string Numero { get; set; } = null!;
        public DateTimeOffset? FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public DateTimeOffset? FechaSalida { get; set; }
        public string HoraSalida { get; set; } = null!;
        public string EstadoTmh { get; set; } = null!;
        public float? PesoBruto { get; set; } = null!;
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public string Licencia { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string VehiculoMarca { get; set; } = null!;
        public string Conductor { get; set; } = null!;
        public string Transportista { get; set; } = null!;
        public string UnidadMedida { get; set; } = null!;
        public string CantidadUnidadMedida { get; set; } = null!;
        public string TipoVehiculo { get; set; } = null!;
    }
}
