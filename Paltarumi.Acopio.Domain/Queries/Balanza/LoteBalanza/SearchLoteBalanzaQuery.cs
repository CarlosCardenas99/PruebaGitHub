using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class SearchLoteBalanzaQuery : SearchQueryBase<SearchLoteBalanzaFilterDto, SearchLoteBalanzaDto>
    {
        public SearchLoteBalanzaQuery(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
