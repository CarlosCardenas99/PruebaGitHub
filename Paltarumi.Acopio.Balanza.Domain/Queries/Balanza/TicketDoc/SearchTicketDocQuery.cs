using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class SearchTicketDocQuery : SearchQueryBase<SearchTicketDocFilterDto, SearchTicketDocDto>
    {
        public SearchTicketDocQuery(SearchParamsDto<SearchTicketDocFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
