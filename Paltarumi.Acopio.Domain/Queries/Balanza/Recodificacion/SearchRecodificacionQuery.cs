using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class SearchRecodificacionQuery : SearchQueryBase<SearchRecodificacionFilterDto, SearchRecodificacionDto>
    {
        public SearchRecodificacionQuery(SearchParamsDto<SearchRecodificacionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
