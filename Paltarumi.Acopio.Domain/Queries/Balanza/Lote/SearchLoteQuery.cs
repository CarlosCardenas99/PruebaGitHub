using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class SearchLoteQuery : SearchQueryBase<LoteFilterDto, SearchLoteDto>
    {
        public SearchLoteQuery(SearchParamsDto<LoteFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
