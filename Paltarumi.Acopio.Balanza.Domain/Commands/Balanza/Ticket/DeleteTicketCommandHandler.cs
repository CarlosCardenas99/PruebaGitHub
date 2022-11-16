using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class DeleteTicketCommandHandler : CommandHandlerBase<DeleteTicketCommand>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public DeleteTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteTicketCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository
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
