using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class DeleteTicketCommandHandler : CommandHandlerBase<DeleteTicketCommand>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public DeleteTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteTicketCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository
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
