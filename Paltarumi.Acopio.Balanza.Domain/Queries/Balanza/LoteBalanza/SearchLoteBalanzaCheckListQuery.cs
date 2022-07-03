using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaCheckListQuery : SearchQueryBase<SearchLoteBalanzaChecklistFilterDto, SearchLoteBalanzaChecklistDto>
    {
        public SearchLoteBalanzaCheckListQuery(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
