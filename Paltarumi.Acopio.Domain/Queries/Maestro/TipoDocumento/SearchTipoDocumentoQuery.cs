using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class SearchTipoDocumentoQuery : SearchQueryBase<TipoDocumentoFilterDto, SearchTipoDocumentoDto>
    {
        public SearchTipoDocumentoQuery(SearchParamsDto<TipoDocumentoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
