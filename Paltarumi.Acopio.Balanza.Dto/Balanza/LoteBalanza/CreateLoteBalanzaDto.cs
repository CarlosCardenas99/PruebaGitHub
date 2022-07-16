using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class CreateLoteBalanzaDto
    {
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdEstadoTipoMaterial { get; set; }
        public string? Observacion { get; set; }
        public IEnumerable<CreateTicketDto>? TicketDetails { get; set; }
        public string? CodigoLote { get; set; }
    }
}
