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


        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<TicketFilterDto> searchParams)
            => await _ticketApplication.Search(searchParams);
    }
}
