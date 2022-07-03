using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.TipoDocumento
{
    public class SearchTipoDocumentoQuery : SearchQueryBase<SearchTipoDocumentoFilterDto, SearchTipoDocumentoDto>
    {
        public SearchTipoDocumentoQuery(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
