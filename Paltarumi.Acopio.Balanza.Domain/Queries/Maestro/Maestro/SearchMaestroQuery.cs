using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro
{
    public class SearchMaestroQuery : SearchQueryBase<SearchMaestroFilterDto, SearchMaestroDto>
    {
        public SearchMaestroQuery(SearchParamsDto<SearchMaestroFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
