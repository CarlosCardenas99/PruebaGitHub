using Paltarumi.Acopio.Maestro.Dto.Conductor;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Transporte;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class GetTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public string? Numero { get; set; }
        public GetTransporteDto? Transporte { get; set; }
        public GetConductorDto? Conductor { get; set; }
        public GetVehiculoDto? Vehiculo { get; set; }
        public GetMaestroDto? UnidadMedida { get; set; }
        public GetMaestroDto? EstadoTmh { get; set; }
        public bool Activo { get; set; }
    }
}
