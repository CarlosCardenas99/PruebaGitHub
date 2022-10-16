using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Maestros.Dto.Acopio.Empresa;
using Paltarumi.Acopio.Maestros.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Proveedor;

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
