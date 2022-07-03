using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class SelectConcesionQuery : SearchQueryBase<SelectConcesionFilterDto, SelectConcesionDto>
    {
        public SelectConcesionQuery(SearchParamsDto<SelectConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}