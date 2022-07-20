using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class GetTicketDocQuery : QueryBase<GetTicketDocDto>
    {
        public GetTicketDocQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
