using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Commands.Common;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = _mapper?.Map<Entity.Lote>(request.CreateDto);

            if (lote != null && _mediator != null)
            {
                // Actualizar la serie harcoded
                var codeResponse = await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1"));
                var code = codeResponse?.Data ?? string.Empty;

                lote.Codigo = code;
                lote.TicketsNavigation =
                    _mapper?.Map<List<Entity.Ticket>>(request.CreateDto.TicketDetails) ?? new List<Entity.Ticket>();

                lote.Activo = true;
                lote.TicketsNavigation.ToList().ForEach(t => { t.Activo = true; });
                lote.Tickets = string.Join(",", lote.TicketsNavigation.Select(x => x.Numero));

                await _loteRepository.AddAsync(lote);

                var loteDto = _mapper?.Map<GetLoteDto>(lote);
                if (loteDto != null)
                {
                    loteDto.TicketDetails =
                        _mapper?.Map<List<GetTicketDto>>(lote.TicketsNavigation) ?? new List<GetTicketDto>();

                    response.UpdateData(loteDto);
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }

            return response;
        }
    }
}
