using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial
{
    public class SearchLeyReferencialQuery : SearchQueryBase<SearchLeyReferencialFilterDto, SearchLeyReferencialDto>
    {
        public SearchLeyReferencialQuery(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
