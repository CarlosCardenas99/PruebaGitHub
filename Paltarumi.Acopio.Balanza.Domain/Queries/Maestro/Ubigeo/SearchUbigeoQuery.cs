using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Ubigeo
{
    public class SearchUbigeoQuery : SearchQueryBase<UbigeoFilterDto, SearchUbigeoDto>
    {
        public SearchUbigeoQuery(SearchParamsDto<UbigeoFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
