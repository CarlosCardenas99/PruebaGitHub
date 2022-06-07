using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class GetTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public TransporteDto Transporte { get; set; }
        public ConductorDto Conductor { get; set; }
        public VehiculoDto Vehiculo { get; set; }
        public MaestroDto UnidadMedida { get; set; }
        public MaestroDto EstadoTmh { get; set; }
        public bool Activo { get; set; }
    }
}
