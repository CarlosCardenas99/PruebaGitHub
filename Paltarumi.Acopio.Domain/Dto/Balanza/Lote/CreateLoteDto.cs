using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class CreateLoteDto : LoteDto
    {
        public IEnumerable<CreateTicketDto>? TicketDetails { get; set; }
    }
}
