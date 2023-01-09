using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
{
    public class TicketApplication : ApplicationBase, ITicketApplication
    {
        public TicketApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto)
            => await _mediator.Send(new CreateTicketCommand(createDto));

        public async Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto)
            => await _mediator.Send(new UpdateTicketCommand(updateDto));

        public async Task<ResponseDto<GetTicketDto>> UpdateNumero(UpdateTicketCodigoDto updateDto)
            => await _mediator.Send(new UpdateTicketCodigoCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteTicketCommand(id));

        public async Task<ResponseDto<GetTicketDto>> Get(int id)
            => await _mediator.Send(new GetTicketQuery(id));
        public async Task<ResponseDto<GetTicketByIdDto>> GetById(int id)
            => await _mediator.Send(new GetTicketByIdQuery(id));
        public async Task<ResponseDto<GetTicketByCodigoDto>> GetByCodigo(int IdVehiculo)
            => await _mediator.Send(new GetTicketByCodigoQuery(IdVehiculo));

        public async Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLoteBalanza)
            => await _mediator.Send(new ListTicketQuery(idLoteBalanza));

        public async Task<ResponseDto<SearchResultDto<byte>>> Export(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams)
            => await _mediator.Send(new ExportLoteTicketQuery(searchParams));

        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> searchParams)
            => await _mediator.Send(new SearchTicketQuery(searchParams));

        public async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams)
            => await _mediator.Send(new SearchConsultaTicketQuery(searchParams));

        public async Task<ResponseDto<ListTicketDto>> ListItem(int idTicket)
            => await _mediator.Send(new ListItemTicketQuery(idTicket));
    }
}
