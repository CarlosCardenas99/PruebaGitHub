using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaCheckListQuery : SearchQueryBase<SearchLoteBalanzaChecklistFilterDto, SearchLoteBalanzaChecklistDto>
    {
        public SearchLoteBalanzaCheckListQuery(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
