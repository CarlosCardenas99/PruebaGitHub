using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class SearchModuloQuery : SearchQueryBase<SearchModuloFilterDto, SearchModuloDto>
    {
        public SearchModuloQuery(SearchParamsDto<SearchModuloFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
