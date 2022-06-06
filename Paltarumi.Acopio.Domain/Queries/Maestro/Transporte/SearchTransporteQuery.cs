using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class SearchTransporteQuery : SearchQueryBase<SearchTransporteFilterDto, SearchTransporteDto>
    {
        public SearchTransporteQuery(SearchParamsDto<SearchTransporteFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
