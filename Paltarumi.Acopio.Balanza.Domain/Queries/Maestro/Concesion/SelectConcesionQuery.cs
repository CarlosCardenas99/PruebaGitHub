using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class SelectConcesionQuery : SearchQueryBase<SelectConcesionFilterDto, SelectConcesionDto>
    {
        public SelectConcesionQuery(SearchParamsDto<SelectConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}