using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Config.Dto.Modulo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Config.Modulo
{
    public class SearchModuloQuery : SearchQueryBase<SearchModuloFilterDto, SearchModuloDto>
    {
        public SearchModuloQuery(SearchParamsDto<SearchModuloFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
