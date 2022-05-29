using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQuery : QueryBase<GetTicketDto>
    {
        public GetTicketQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}