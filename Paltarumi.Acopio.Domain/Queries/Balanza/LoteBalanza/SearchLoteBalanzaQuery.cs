using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class SearchLoteBalanzaQuery : SearchQueryBase<SearchLoteBalanzaFilterDto, SearchLoteBalanzaDto>
    {
        public SearchLoteBalanzaQuery(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
