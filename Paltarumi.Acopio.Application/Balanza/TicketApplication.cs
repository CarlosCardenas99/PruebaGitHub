using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Balanza.Ticket;

namespace Paltarumi.Acopio.Application.Balanza
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

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteTicketCommand(id));

        public async Task<ResponseDto<GetTicketDto>> Get(int id)
            => await _mediator.Send(new GetTicketQuery(id));
        public async Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLoteBalanza)
            => await _mediator.Send(new ListTicketQuery(idLoteBalanza));

        public async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> searchParams)
            => await _mediator.Send(new SearchTicketQuery(searchParams));
    }
}
