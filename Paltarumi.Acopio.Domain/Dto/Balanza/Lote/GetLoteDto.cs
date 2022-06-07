using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class GetLoteDto
    {
        public int IdLote { get; set; }
        public string? Codigo { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? HoraIngreso { get; set; }
        public DateTime? FechaAcopio { get; set; }
        public string? HoraAcopio { get; set; }
        public string? CantidadSacos { get; set; }
        public float? Tmh100 { get; set; }
        public float? TmhBase { get; set; }
        public float? Tmh { get; set; }
        public float? Humedad100 { get; set; }
        public float? HumedadBase { get; set; }
        public float? Humedad { get; set; }
        public float Tms100 { get; set; }
        public float TmsBase { get; set; }
        public float? Tms { get; set; }
        public GetConcesionDto Concesion { get; set; }
        public GetMaestroDto EstadoTipoMaterial { get; set; }
        public GetProveedorDto Proveedor { get; set; }
        public GetMaestroDto Estado { get; set; }
        public string? Observacion { get; set; }
        public int? IdUsuarioCreate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
