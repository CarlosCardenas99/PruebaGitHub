using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class DeleteTicketDocCommandHandler : CommandHandlerBase<DeleteTicketDocCommand>
    {
        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public DeleteTicketDocCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteTicketDocCommandValidator validator,
            IRepository<Entity.TicketDoc> ticketdocRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _ticketdocRepository = ticketdocRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteTicketDocCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var ticketdoc = await _ticketdocRepository.GetByAsync(x => x.IdTicketDoc == request.Id);

            if (ticketdoc != null)
            {
                ticketdoc.Activo = false;
                await _ticketdocRepository.UpdateAsync(ticketdoc);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
