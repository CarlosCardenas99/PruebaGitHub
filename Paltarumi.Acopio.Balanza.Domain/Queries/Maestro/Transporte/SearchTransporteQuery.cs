using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Transporte
{
    public class SearchTransporteQuery : SearchQueryBase<SearchTransporteFilterDto, SearchTransporteDto>
    {
        public SearchTransporteQuery(SearchParamsDto<SearchTransporteFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
