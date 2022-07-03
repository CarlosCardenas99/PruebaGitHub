using Paltarumi.Acopio.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class GetLoteBalanzaDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetMaestroDto? Estado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
