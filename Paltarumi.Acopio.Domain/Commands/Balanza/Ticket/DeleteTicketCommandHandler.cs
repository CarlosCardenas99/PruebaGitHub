using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class DeleteTicketCommandHandler : CommandHandlerBase<DeleteTicketCommand>
    {
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public DeleteTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteTicketCommandValidator validator,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var ticket = await _ticketRepository.GetByAsync(x => x.IdTicket == request.Id);

            if (ticket != null)
            {
                ticket.Activo = false;
                await _ticketRepository.UpdateAsync(ticket);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
