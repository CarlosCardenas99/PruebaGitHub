using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchConsultaTicketQuery : SearchQueryBase<SearchConsultaTicketFilterDto, SearchConsultaTicketDto>
    {
        public SearchConsultaTicketQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
