using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class SearchDuenoMuestraQuery : SearchQueryBase<SearchDuenoMuestraFilterDto, SearchDuenoMuestraDto>
    {
        public SearchDuenoMuestraQuery(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
