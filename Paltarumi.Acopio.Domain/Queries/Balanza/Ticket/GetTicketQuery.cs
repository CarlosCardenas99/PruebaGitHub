using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQuery : QueryBase<GetTicketDto>
    {
        public GetTicketQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}