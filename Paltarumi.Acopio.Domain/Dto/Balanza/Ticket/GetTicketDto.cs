namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class GetTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public int IdLote { get; set; }
        public bool Activo { get; set; }
    }
}
