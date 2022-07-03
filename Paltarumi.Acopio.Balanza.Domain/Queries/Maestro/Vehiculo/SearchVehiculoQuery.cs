using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class SearchVehiculoQuery : SearchQueryBase<SearchVehiculoFilterDto, SearchVehiculoDto>
    {
        public SearchVehiculoQuery(SearchParamsDto<SearchVehiculoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
