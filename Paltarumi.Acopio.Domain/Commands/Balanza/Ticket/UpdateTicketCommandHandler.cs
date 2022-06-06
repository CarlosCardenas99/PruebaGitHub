using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommandHandler : CommandHandlerBase<UpdateTicketCommand, GetTicketDto>
    {
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public UpdateTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateTicketCommandValidator validator,
            IRepositoryBase<Entity.Ticket> ticketRepository
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
