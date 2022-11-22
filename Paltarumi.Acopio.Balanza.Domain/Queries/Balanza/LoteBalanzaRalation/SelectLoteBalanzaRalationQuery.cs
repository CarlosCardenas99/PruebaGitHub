using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class SelectLoteBalanzaRalationQuery : SearchQueryBase<SelectLoteBalanzaRalationFilterDto, SelectLoteBalanzaRalationDto>
    {
        public SelectLoteBalanzaRalationQuery(SearchParamsDto<SelectLoteBalanzaRalationFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
