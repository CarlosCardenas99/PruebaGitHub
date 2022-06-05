using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class SearchVehiculoQuery : SearchQueryBase<VehiculoFilterDto, SearchVehiculoDto>
    {
        public SearchVehiculoQuery(SearchParamsDto<VehiculoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
