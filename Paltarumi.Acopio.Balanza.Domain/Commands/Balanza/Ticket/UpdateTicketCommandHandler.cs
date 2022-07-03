using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommandHandler : CommandHandlerBase<UpdateTicketCommand, GetTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public UpdateTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateTicketCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto<GetTicketDto>> HandleCommand(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = await _ticketRepository.GetByAsync(x => x.IdTicket == request.UpdateDto.IdTicket);

            if (ticket != null)
            {
                _mapper?.Map(request.UpdateDto, ticket);
                await _ticketRepository.UpdateAsync(ticket);
            }

            var ticketDto = _mapper?.Map<GetTicketDto>(ticket);
            if (ticketDto != null) response.UpdateData(ticketDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
