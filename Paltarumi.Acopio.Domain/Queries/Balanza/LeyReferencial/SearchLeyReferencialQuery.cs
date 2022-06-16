using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class SearchLeyReferencialQuery : SearchQueryBase<SearchLeyReferencialFilterDto, SearchLeyReferencialDto>
    {
        public SearchLeyReferencialQuery(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
