using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQuery : SearchQueryBase<SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        public SearchLoteCodigoQuery(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
