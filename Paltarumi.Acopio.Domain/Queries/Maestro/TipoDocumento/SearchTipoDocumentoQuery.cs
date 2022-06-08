using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class SearchTipoDocumentoQuery : SearchQueryBase<SearchTipoDocumentoFilterDto, SearchTipoDocumentoDto>
    {
        public SearchTipoDocumentoQuery(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
