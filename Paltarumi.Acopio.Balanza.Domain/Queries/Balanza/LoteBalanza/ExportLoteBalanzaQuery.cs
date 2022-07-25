using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ExportLoteBalanzaQuery : SearchQueryBase<SearchLoteBalanzaFilterDto, byte>
    {
        public ExportLoteBalanzaQuery(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
