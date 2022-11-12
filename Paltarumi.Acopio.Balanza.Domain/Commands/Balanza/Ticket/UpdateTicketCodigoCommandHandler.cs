using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCodigoCommandHandler : CommandHandlerBase<UpdateTicketCodigoCommand, GetTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public UpdateTicketCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateTicketCodigoCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto<GetTicketDto>> HandleCommand(UpdateTicketCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = await _ticketRepository.GetByAsync(x => x.IdTicket == request.UpdateDto.IdTicket);

            if (ticket != null && _mediator != null)
           {
                var numero = (await _mediator.Send(new CreateCodeCommand(CONST_ACOPIO.CODIGOCORRELATIVO_TIPO.TICKET, request.UpdateDto.Serie, request.UpdateDto.IdEmpresa, request.UpdateDto.IdSucursal)))?.Data?.Numero ?? string.Empty;

                ticket.Numero = numero ?? string.Empty;

                await _ticketRepository.UpdateAsync(ticket);
                await _ticketRepository.SaveAsync();
            }

            var ticketDto = _mapper?.Map<GetTicketDto>(ticket);
            if (ticketDto != null) response.UpdateData(ticketDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}