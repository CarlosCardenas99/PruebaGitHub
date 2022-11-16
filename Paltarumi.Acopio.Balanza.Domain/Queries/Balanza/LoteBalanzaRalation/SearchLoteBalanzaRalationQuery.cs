using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class SearchLoteBalanzaRalationQuery : SearchQueryBase<SearchLoteBalanzaRalationFilterDto, SearchLoteBalanzaRalationDto>
    {
        public SearchLoteBalanzaRalationQuery(SearchParamsDto<SearchLoteBalanzaRalationFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
