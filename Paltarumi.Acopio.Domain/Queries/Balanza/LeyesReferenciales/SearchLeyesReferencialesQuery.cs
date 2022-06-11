using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class SearchLeyesReferencialesQuery : SearchQueryBase<LeyesReferencialesFilterDto, SearchLeyesReferencialesDto>
    {
        public SearchLeyesReferencialesQuery(SearchParamsDto<LeyesReferencialesFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
