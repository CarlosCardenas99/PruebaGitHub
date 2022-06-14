using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaCheckListQuery: SearchQueryBase<SearchLoteBalanzaChecklistFilterDto, SearchLoteBalanzaChecklistDto>
    {
        public SearchLoteBalanzaCheckListQuery(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
