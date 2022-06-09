using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class GetTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public string Numero { get; set; } = null!;
        public GetTransporteDto? Transporte { get; set; }
        public GetConductorDto? Conductor { get; set; }
        public GetVehiculoDto? Vehiculo { get; set; }
        public GetMaestroDto? UnidadMedida { get; set; }
        public GetMaestroDto? EstadoTmh { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
        public bool Activo { get; set; }
    }
}
