using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class SearchMaestroQuery : SearchQueryBase<MaestroFilterDto, SearchMaestroDto>
    {
        public SearchMaestroQuery(SearchParamsDto<MaestroFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
