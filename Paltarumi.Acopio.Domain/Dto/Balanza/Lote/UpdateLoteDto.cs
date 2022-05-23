using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class UpdateLoteDto : LoteDto
    {
        public int IdLote { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<UpdateTicketDto>? TicketDetails { get; set; }
    }
}
