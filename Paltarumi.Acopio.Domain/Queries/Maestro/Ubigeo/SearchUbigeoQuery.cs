using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class SearchUbigeoQuery : SearchQueryBase<UbigeoFilterDto, SearchUbigeoDto>
    {
        public SearchUbigeoQuery(SearchParamsDto<UbigeoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
