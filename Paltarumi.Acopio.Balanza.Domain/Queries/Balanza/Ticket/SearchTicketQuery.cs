using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQuery : SearchQueryBase<SearchTicketFilterDto, SearchTicketDto>
    {
        public SearchTicketQuery(SearchParamsDto<SearchTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
