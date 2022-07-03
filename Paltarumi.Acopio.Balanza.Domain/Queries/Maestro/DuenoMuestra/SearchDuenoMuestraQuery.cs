using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class SearchDuenoMuestraQuery : SearchQueryBase<SearchDuenoMuestraFilterDto, SearchDuenoMuestraDto>
    {
        public SearchDuenoMuestraQuery(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
