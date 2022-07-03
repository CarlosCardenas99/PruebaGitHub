using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class SearchUbigeoQuery : SearchQueryBase<UbigeoFilterDto, SearchUbigeoDto>
    {
        public SearchUbigeoQuery(SearchParamsDto<UbigeoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
