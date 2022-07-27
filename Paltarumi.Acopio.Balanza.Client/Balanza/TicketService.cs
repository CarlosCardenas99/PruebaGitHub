using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class TicketService : BaseService
    {
        protected override string ApiController => "api/ticket";

        public TicketService(ServiceOptions options) : base(options)
        {

        }
        public async Task<ResponseDto<GetTicketDto>> Insert(CreateTicketDto createDto)
            => await Post<CreateTicketDto, GetTicketDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto)
            => await Put<UpdateTicketDto, GetTicketDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetTicketDto>> Get(int id)
            => await Get<GetTicketDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLote)
            => await Get<IEnumerable<ListTicketDto>>($"/list/{idLote}")!;

        public async Task<ResponseDto<ListTicketDto>> ListItem(int id)
            => await Get<ListTicketDto>($"/listitem/{id}")!;

        public async Task<HttpResponseMessage> Export(SearchParamsDto<SearchConsultaTicketFilterDto> exportParams)
            => await PostFile("/exportExcel", exportParams)!;

        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> filter)
            => await Post<SearchParamsDto<SearchTicketFilterDto>, SearchResultDto<SearchTicketDto>>("/search", filter)!;

        public async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchTicket(SearchParamsDto<SearchConsultaTicketFilterDto> filter)
            => await Post<SearchParamsDto<SearchConsultaTicketFilterDto>, SearchResultDto<SearchConsultaTicketDto>>("/searchby", filter)!;
    }
}
