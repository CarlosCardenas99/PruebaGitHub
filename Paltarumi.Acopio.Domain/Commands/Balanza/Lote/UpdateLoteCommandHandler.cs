using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class UpdateLoteCommandHandler : CommandHandlerBase<UpdateLoteCommand, GetLoteDto>
    {
        public readonly IRepositoryBase<Entity.Lote> _loteRepository;
        public readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public UpdateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteRepository = loteRepository;
            _ticketRepository = ticketRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(UpdateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = await _loteRepository.GetByAsync(x => x.IdLote == request.UpdateDto.IdLote, x => x.TicketsNavigation);

            if (lote != null)
            {
                #region Update Existing

                _mapper?.Map(request.UpdateDto, lote);

                foreach (var ticket in (lote.TicketsNavigation ?? new List<Entity.Ticket>()))
                {
                    var ticketDto = request.UpdateDto?.TicketDetails?.FirstOrDefault(x => x.IdTicket == ticket.IdTicket);
                    if (ticketDto != null)
                    {
                        _mapper?.Map(ticketDto, ticket);
                    }
                }

                await _loteRepository.UpdateAsync(lote);

                #endregion

                #region Add Non Existing
                var ticketIds = lote.TicketsNavigation?.Select(x => x.IdTicket) ?? new List<int>();
                var newTicketDtos =
                    request.UpdateDto?.TicketDetails?.Where(x => !ticketIds.Contains(x.IdTicket)) ??
                    new List<UpdateTicketDto>();

                var newTickets = _mapper?.Map<IEnumerable<Entity.Ticket>>(newTicketDtos) ??
                    new List<Entity.Ticket>();

                newTickets.ToList().ForEach(t =>
                {
                    t.IdLote = lote.IdLote;
                    t.IdLoteNavigation = null;
                    t.Activo = true;
                    if (lote?.TicketsNavigation != null) lote.TicketsNavigation.Add(t);
                });

                await _ticketRepository.AddAsync(newTickets.ToArray());

                lote.Tickets = string.Join(
                    ",", lote.TicketsNavigation?.Select(x => x.Numero) ?? new List<string>()) ?? string.Empty;
                await _loteRepository.UpdateAsync(lote);

                #endregion

                var loteDto = _mapper?.Map<GetLoteDto>(lote);
                if (loteDto != null)
                {
                    loteDto.TicketDetails =
                        _mapper?.Map<List<GetTicketDto>>(lote?.TicketsNavigation) ?? new List<GetTicketDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
