using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController
    {
        private readonly ITicketApplication _ticketApplication;

        public TicketController(ITicketApplication ticketApplication)
            => _ticketApplication = ticketApplication;

        [HttpPost]
        public async Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto)
            => await _ticketApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto)
            => await _ticketApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _ticketApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetTicketDto>> Get(int id)
            => await _ticketApplication.Get(id);

        [HttpGet("list/{idLoteBalanza}")]
        public async Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLoteBalanza)
            => await _ticketApplication.List(idLoteBalanza);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> searchParams)
            => await _ticketApplication.Search(searchParams);

        [HttpPost("searchBy")]
        public async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams)
           => await _ticketApplication.SearchQuery(searchParams);
    }
}
