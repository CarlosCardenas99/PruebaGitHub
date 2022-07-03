using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchConsultaTicketQuery : SearchQueryBase<SearchConsultaTicketFilterDto, SearchConsultaTicketDto>
    {
        public SearchConsultaTicketQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
