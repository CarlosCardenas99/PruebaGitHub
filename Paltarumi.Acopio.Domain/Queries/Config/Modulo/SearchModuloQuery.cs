using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Config.Modulo;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class SearchModuloQuery : SearchQueryBase<SearchModuloFilterDto, SearchModuloDto>
    {
        public SearchModuloQuery(SearchParamsDto<SearchModuloFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
