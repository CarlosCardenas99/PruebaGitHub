using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class SelectConcesionQuery : SearchQueryBase<SelectConcesionFilterDto, SelectConcesionDto>
    {
        public SelectConcesionQuery(SearchParamsDto<SelectConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}