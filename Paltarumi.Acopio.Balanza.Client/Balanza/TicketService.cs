using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class TicketService : BaseService
    {
        protected override string ApiController => "api/ticket";

        public TicketService(ServiceOptions options) : base(options)
        {

        }

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetTicketDto>>($"/{id}");
            return ResponseData(response);
        }

        public Response list(int idLote)
        {
            try
            {
                var response = EntityGet<ResponseDto<IEnumerable<ListTicketDto>>>($"/list/{idLote}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }

        public Response listarTicket(SearchParamsDto<SearchTicketFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchTicketFilterDto>, ResponseDto<SearchResultDto<SearchTicketDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response SearchTicket(SearchParamsDto<SearchConsultaTicketFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchConsultaTicketFilterDto>, ResponseDto<SearchResultDto<SearchConsultaTicketDto>>>("/searchby", filter);
            return ResponseSearchResult(response);
        }
    }
}
