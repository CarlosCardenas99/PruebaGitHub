
namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class ListTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public bool Activo { get; set; }
        public string Conductor { get; set; }
        public string ConductorLicencia { get; set; }
        public string ConductorDni { get; set; }
        public string Transporte { get; set; }
        public string TransporteRuc { get; set; }
        public string UnidadMedida { get; set; }
        public string VehiculoMarca { get; set; }
        public string VehiculoTipo { get; set; }
        public string Placa { get; set; }
        public string EstadoTmh { get; set; }
        public string FechaHoraIngreso { get; set; }
        public string FechaHoraSalida { get; set; }
    }
}
