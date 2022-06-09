using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class UpdateLoteDto
    {
        public int IdLote { get; set; }
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdEstadoTipoMaterial { get; set; }
        public string? Observacion { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<UpdateTicketDto>? TicketDetails { get; set; }
    }
}
