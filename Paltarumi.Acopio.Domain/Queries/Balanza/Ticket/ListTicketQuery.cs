using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class ListTicketQuery : QueryBase<IEnumerable<ListTicketDto>>
    {
        public ListTicketQuery(int idLoteBalanza) => IdLoteBalanza = idLoteBalanza;
        public int IdLoteBalanza { get; set; }
    }
}