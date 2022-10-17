using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Maestros.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class GetLoteBalanzaCodigoDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetLoteEstadoDto? Estado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
