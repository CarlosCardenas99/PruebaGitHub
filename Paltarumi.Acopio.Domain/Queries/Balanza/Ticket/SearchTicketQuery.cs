using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQuery : SearchQueryBase<SearchTicketFilterDto, SearchTicketDto>
    {
        public SearchTicketQuery(SearchParamsDto<SearchTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
