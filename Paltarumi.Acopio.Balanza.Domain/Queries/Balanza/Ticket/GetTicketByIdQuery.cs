using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;


namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByIdQuery : QueryBase<GetTicketByIdDto>

    {
        public GetTicketByIdQuery(int id) => IdTicket = id;
        public int IdTicket { get; set; }

    }
}
