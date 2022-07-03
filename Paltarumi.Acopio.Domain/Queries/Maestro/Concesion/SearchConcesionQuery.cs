using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class SearchConcesionQuery : SearchQueryBase<SearchConcesionFilterDto, SearchConcesionDto>
    {
        public SearchConcesionQuery(SearchParamsDto<SearchConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
