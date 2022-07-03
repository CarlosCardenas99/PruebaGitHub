using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class SearchTransporteQuery : SearchQueryBase<SearchTransporteFilterDto, SearchTransporteDto>
    {
        public SearchTransporteQuery(SearchParamsDto<SearchTransporteFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
