using Paltarumi.Acopio.Maestros.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Vehiculo;

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
