using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Apis.Controllers.Base;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ApiControllerBase
    {
        private readonly ITicketApplication _ticketApplication;

        public TicketController(IServiceProvider serviceProvider, ITicketApplication ticketApplication) : base(serviceProvider)
            => _ticketApplication = ticketApplication;

        [HttpPost]
        public async Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto)
            => await _ticketApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto)
            => await _ticketApplication.Update(updateDto);

        [HttpPut("updateNumero")]
        public async Task<ResponseDto<GetTicketDto>> UpdateNumero(UpdateTicketCodigoDto updateDto)
            => await _ticketApplication.UpdateNumero(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _ticketApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetTicketDto>> Get(int id)
            => await _ticketApplication.Get(id); 
        
        [HttpGet("byid/{id}")]
        public async Task<ResponseDto<GetTicketByIdDto>> GetById(int id)
            => await _ticketApplication.GetById(id);

        [HttpGet("list/{idLoteBalanza}")]
        public async Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLoteBalanza)
            => await _ticketApplication.List(idLoteBalanza);

        [HttpGet("listitem/{id}")]
        public async Task<ResponseDto<ListTicketDto>> ListItem(int id)
            => await _ticketApplication.ListItem(id);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> searchParams)
            => await _ticketApplication.Search(searchParams);

        [HttpPost("searchBy")]
        public async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams)
           => await _ticketApplication.SearchQuery(searchParams);

        [HttpPost("exportExcel")]
        public async Task<FileResult> Export(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams)
            => await DownloadFile(
                (await _ticketApplication.Export(searchParams)).Data?.Items?.ToArray() ?? new byte[0],
                string.Format($"{Domain.Resources.Balanza.Ticket.ExcelReportName}.xlsx", DateTimeOffset.Now)
            );

    }
}
