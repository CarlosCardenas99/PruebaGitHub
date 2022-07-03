using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQuery : SearchQueryBase<SearchTicketFilterDto, SearchTicketDto>
    {
        public SearchTicketQuery(SearchParamsDto<SearchTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
