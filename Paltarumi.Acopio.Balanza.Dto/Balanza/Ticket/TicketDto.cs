
namespace Paltarumi.Acopio.Balanza.Dto.Ticket
{
    public class TicketDto
    {
        public int IdLoteBalanza { get; set; }
        public string? Numero { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset FechaSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public Single PesoBruto100 { get; set; }
        public Single PesoBrutoBase { get; set; }
        public Single PesoBruto { get; set; }
        public Single Tara { get; set; }
        public Single PesoNeto100 { get; set; }
        public Single PesoNetoBase { get; set; }
        public Single PesoNeto { get; set; }
        public string? Grr { get; set; }
        public string? Grt { get; set; }
        public int IdTransporte { get; set; }
        public int IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string? Observacion { get; set; }
    }
}
