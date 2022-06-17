using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchConsultaTicketQuery : SearchQueryBase<SearchConsultaTicketFilterDto, SearchConsultaTicketDto>
    {
        public SearchConsultaTicketQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
