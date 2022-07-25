using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class ListItemTicketQuery : QueryBase<ListTicketDto>
    {
        public ListItemTicketQuery(int idTicket) => IdTicket = idTicket;
        public int IdTicket { get; set; }
    }
}