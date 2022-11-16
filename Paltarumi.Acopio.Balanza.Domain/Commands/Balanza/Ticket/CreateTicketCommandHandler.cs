using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommandHandler : CommandHandlerBase<CreateTicketCommand, GetTicketDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public CreateTicketCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateTicketCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository

        ) : base(unitOfWork, mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto<GetTicketDto>> HandleCommand(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = _mapper?.Map<Entities.Ticket>(request.CreateDto);

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
