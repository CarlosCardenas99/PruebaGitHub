using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class CreateTicketDocCommandHandler : CommandHandlerBase<CreateTicketDocCommand, GetTicketDocDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public CreateTicketDocCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateTicketDocCommandValidator validator,
            IRepository<Entity.TicketDoc> ticketdocRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _ticketdocRepository = ticketdocRepository;
        }

        public override async Task<ResponseDto<GetTicketDocDto>> HandleCommand(CreateTicketDocCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDocDto>();
            var ticketdoc = _mapper?.Map<Entity.TicketDoc>(request.CreateDto);

            if (ticketdoc != null)
            {
                ticketdoc.Activo = true;


                await _ticketdocRepository.AddAsync(ticketdoc);
                await _ticketdocRepository.SaveAsync();
            }

            var ticketdocDto = _mapper?.Map<GetTicketDocDto>(ticketdoc);
            if (ticketdocDto != null) response.UpdateData(ticketdocDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
