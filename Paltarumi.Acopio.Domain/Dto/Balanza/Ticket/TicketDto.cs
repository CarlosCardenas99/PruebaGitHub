namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class TicketDto
    {
        public int IdLoteBalanza { get; set; }
        public string Numero { get; set; } = null!;
        public DateTimeOffset FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public DateTimeOffset? FechaSalida { get; set; }
        public string? HoraSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public float PesoBruto100 { get; set; }
        public float PesoBrutoBase { get; set; }
        public float PesoBruto { get; set; }
        public float Tara { get; set; }
        public float PesoNeto100 { get; set; }
        public float PesoNetoBase { get; set; }
        public float PesoNeto { get; set; }
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public int IdTransporte { get; set; }
        public int IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int IdTipoMineral { get; set; }
        public int IdUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string Observacion { get; set; } = null!;
    }
}
