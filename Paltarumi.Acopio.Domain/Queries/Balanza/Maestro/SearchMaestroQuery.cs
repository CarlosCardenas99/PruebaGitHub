using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class SearchMaestroQuery : SearchQueryBase<SearchMaestroFilterDto, SearchMaestroDto>
    {
        public SearchMaestroQuery(SearchParamsDto<SearchMaestroFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
