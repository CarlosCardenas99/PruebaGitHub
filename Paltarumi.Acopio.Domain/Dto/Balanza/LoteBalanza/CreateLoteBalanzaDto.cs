using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaDto
    {
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdEstadoTipoMaterial { get; set; }
        public string? Observacion { get; set; }
        public int? IdUsuarioCreate { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public IEnumerable<CreateTicketDto>? TicketDetails { get; set; }
    }
}
