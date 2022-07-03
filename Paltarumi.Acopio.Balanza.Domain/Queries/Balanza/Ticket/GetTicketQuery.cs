using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQuery : QueryBase<GetTicketDto>
    {
        public GetTicketQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}