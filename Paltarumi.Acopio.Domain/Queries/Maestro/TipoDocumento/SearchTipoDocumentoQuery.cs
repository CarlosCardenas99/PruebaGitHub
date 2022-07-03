using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class SearchTipoDocumentoQuery : SearchQueryBase<SearchTipoDocumentoFilterDto, SearchTipoDocumentoDto>
    {
        public SearchTipoDocumentoQuery(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
