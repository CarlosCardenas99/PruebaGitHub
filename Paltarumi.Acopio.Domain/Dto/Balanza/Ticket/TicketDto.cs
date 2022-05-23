namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class TicketDto
    {
        public string Numero { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public DateTime FechaSalida { get; set; }
        public string HoraSalida { get; set; } = null!;
        public float PesoBruto { get; set; }
        public float Tara { get; set; }
        public float PesoNeto { get; set; }
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public int IdTransportista { get; set; }
        public int IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int CodigoUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string Observacion { get; set; } = null!;
    }
}
