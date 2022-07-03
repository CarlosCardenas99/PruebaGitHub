using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQuery : SearchQueryBase<SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        public SearchLoteCodigoQuery(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
