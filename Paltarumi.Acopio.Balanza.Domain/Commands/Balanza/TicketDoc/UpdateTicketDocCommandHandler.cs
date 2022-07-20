using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class UpdateTicketDocCommandHandler : CommandHandlerBase<UpdateTicketDocCommand, GetTicketDocDto>
    {
        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public UpdateTicketDocCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateTicketDocCommandValidator validator,
            IRepository<Entity.TicketDoc> ticketdocRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _ticketdocRepository = ticketdocRepository;
        }

        public override async Task<ResponseDto<GetTicketDocDto>> HandleCommand(UpdateTicketDocCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDocDto>();
            var ticketdoc = await _ticketdocRepository.GetByAsync(x => x.IdTicketDoc == request.UpdateDto.IdTicketDoc);

            if (ticketdoc != null)
            {
                _mapper?.Map(request.UpdateDto, ticketdoc);
                await _ticketdocRepository.UpdateAsync(ticketdoc);
            }

            var ticketdocDto = _mapper?.Map<GetTicketDocDto>(ticketdoc);
            if (ticketdocDto != null) response.UpdateData(ticketdocDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
