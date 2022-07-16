using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class GetLoteBalanzaDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public float? Humedad { get; set; }
        public float? Tms { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetMaestroDto? Estado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
