using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class ListTicketQuery : QueryBase<IEnumerable<ListTicketDto>>
    {
        public ListTicketQuery(int idLoteBalanza) => IdLoteBalanza = idLoteBalanza;
        public int IdLoteBalanza { get; set; }
    }
}