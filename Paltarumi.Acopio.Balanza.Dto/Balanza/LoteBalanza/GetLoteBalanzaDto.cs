using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class GetLoteBalanzaDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? Tms { get; set; }
        public GetEmpresaDto? Empresa { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetLoteEstadoDto? LoteEstado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
