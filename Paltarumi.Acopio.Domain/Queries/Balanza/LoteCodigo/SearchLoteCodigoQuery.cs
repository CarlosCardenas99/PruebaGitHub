using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQuery : SearchQueryBase<LoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        public SearchLoteCodigoQuery(SearchParamsDto<LoteCodigoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
