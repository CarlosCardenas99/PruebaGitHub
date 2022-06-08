using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class SearchLoteQuery : SearchQueryBase<SearchLoteFilterDto, SearchLoteDto>
    {
        public SearchLoteQuery(SearchParamsDto<SearchLoteFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
