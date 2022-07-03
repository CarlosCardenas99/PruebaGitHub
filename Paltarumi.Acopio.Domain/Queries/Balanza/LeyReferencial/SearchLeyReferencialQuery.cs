using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class SearchLeyReferencialQuery : SearchQueryBase<SearchLeyReferencialFilterDto, SearchLeyReferencialDto>
    {
        public SearchLeyReferencialQuery(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
