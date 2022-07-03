using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class SearchMaestroQuery : SearchQueryBase<SearchMaestroFilterDto, SearchMaestroDto>
    {
        public SearchMaestroQuery(SearchParamsDto<SearchMaestroFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
