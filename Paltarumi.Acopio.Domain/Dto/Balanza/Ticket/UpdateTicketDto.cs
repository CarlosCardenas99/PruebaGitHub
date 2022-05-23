namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class UpdateTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public bool Activo { get; set; }
    }
}
