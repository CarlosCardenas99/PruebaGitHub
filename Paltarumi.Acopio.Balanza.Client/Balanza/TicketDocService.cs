using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class TicketDocService : BaseService
    {
        protected override string ApiController => "api/TicketDoc";

        public TicketDocService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetTicketDocDto>> insert(CreateTicketDocDto createDto)
            => await Post<CreateTicketDocDto, GetTicketDocDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetTicketDocDto>> update(UpdateTicketDocDto updateDto)
           => await Put<UpdateTicketDocDto, GetTicketDocDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetTicketDocDto>> Get(int id)
            => await Get<GetTicketDocDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListTicketDocDto>>> List(int idLote)
           => await Get<IEnumerable<ListTicketDocDto>>($"/list/{idLote}")!;

        public async Task<ResponseDto<SearchResultDto<SearchTicketDocDto>>> Search(SearchParamsDto<SearchTicketDocFilterDto> filter)
            => await Post<SearchParamsDto<SearchTicketDocFilterDto>, SearchResultDto<SearchTicketDocDto>>("/search", filter)!;

        //public async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchTicket(SearchParamsDto<SearchConsultaTicketFilterDto> filter)
        //    => await Post<SearchParamsDto<SearchConsultaTicketFilterDto>, SearchResultDto<SearchConsultaTicketDto>>("/searchby", filter)!;
    }
}
