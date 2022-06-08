using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class SearchConcesionQuery : SearchQueryBase<SearchConcesionFilterDto, SearchConcesionDto>
    {
        public SearchConcesionQuery(SearchParamsDto<SearchConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
