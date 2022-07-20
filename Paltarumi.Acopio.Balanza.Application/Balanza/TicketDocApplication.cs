using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
{
    public class TicketDocApplication : ApplicationBase, ITicketDocApplication
    {
        public TicketDocApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetTicketDocDto>> Create(CreateTicketDocDto createDto)
            => await _mediator.Send(new CreateTicketDocCommand(createDto));

        public async Task<ResponseDto<GetTicketDocDto>> Update(UpdateTicketDocDto updateDto)
            => await _mediator.Send(new UpdateTicketDocCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteTicketDocCommand(id));

        public async Task<ResponseDto<GetTicketDocDto>> Get(int id)
            => await _mediator.Send(new GetTicketDocQuery(id));

        public async Task<ResponseDto<IEnumerable<ListTicketDocDto>>> List()
            => await _mediator.Send(new ListTicketDocQuery());

        public async Task<ResponseDto<SearchResultDto<SearchTicketDocDto>>> Search(SearchParamsDto<SearchTicketDocFilterDto> searchParams)
            => await _mediator.Send(new SearchTicketDocQuery(searchParams));
    }
}
