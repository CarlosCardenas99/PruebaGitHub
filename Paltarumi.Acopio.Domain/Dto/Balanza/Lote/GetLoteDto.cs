using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class GetLoteDto : LoteDto
    {
        public int IdLote { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<GetTicketDto>? TicketDetails { get; set; }
    }
}
