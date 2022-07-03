using Paltarumi.Acopio.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Dto.Balanza.Ticket
{
    public class GetTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public GetTransporteDto? Transporte { get; set; }
        public GetConductorDto? Conductor { get; set; }
        public GetVehiculoDto? Vehiculo { get; set; }
        public GetMaestroDto? UnidadMedida { get; set; }
        public GetMaestroDto? EstadoTmh { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
        public bool Activo { get; set; }
    }
}
