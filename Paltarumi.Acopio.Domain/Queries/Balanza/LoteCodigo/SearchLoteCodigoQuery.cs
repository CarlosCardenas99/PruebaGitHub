using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQuery : SearchQueryBase<SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        public SearchLoteCodigoQuery(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
