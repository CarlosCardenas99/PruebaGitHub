using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommandHandler : CommandHandlerBase<CreateTicketCommand, GetTicketDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public CreateTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateTicketCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository

        ) : base(unitOfWork, mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto<GetTicketDto>> HandleCommand(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = _mapper?.Map<Entity.Ticket>(request.CreateDto);

            if (ticket != null)
            {
                ticket.Activo = true;

                await _ticketRepository.AddAsync(ticket);
                await _ticketRepository.SaveAsync();
            }

            var ticketDto = _mapper?.Map<GetTicketDto>(ticket);
            if (ticketDto != null) response.UpdateData(ticketDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
