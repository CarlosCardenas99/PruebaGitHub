using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class SearchVehiculoQuery : SearchQueryBase<SearchVehiculoFilterDto, SearchVehiculoDto>
    {
        public SearchVehiculoQuery(SearchParamsDto<SearchVehiculoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
