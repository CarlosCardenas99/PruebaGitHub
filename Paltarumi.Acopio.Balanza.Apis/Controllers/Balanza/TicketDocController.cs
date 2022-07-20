using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/ticketdoc")]
    public class TicketDocController
    {
        private readonly ITicketDocApplication _ticketdocApplication;

        public TicketDocController(ITicketDocApplication ticketdocApplication)
            => _ticketdocApplication = ticketdocApplication;

        [HttpPost]
        public async Task<ResponseDto<GetTicketDocDto>> Create(CreateTicketDocDto createDto)
            => await _ticketdocApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetTicketDocDto>> Update(UpdateTicketDocDto updateDto)
            => await _ticketdocApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _ticketdocApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetTicketDocDto>> Get(int id)
            => await _ticketdocApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListTicketDocDto>>> List()
            => await _ticketdocApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTicketDocDto>>> Search(SearchParamsDto<SearchTicketDocFilterDto> searchParams)
            => await _ticketdocApplication.Search(searchParams);
    }
}
