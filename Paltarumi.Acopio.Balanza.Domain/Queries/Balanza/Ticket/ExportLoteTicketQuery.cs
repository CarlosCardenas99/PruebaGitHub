using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ExportLoteTicketQuery : SearchQueryBase<SearchConsultaTicketFilterDto, byte>
    {
        public ExportLoteTicketQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
