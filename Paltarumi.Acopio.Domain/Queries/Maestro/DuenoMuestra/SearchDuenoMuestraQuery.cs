using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class SearchDuenoMuestraQuery : SearchQueryBase<SearchDuenoMuestraFilterDto, SearchDuenoMuestraDto>
    {
        public SearchDuenoMuestraQuery(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
