using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQueryHandler : QueryHandlerBase<GetTicketQuery, GetTicketDto>
    {
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public GetTicketQueryHandler(
            IMapper mapper,
            GetTicketQueryValidator validator,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<GetTicketDto>> HandleQuery(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = await _ticketRepository.GetByAsync(x => x.IdTicket == request.Id);
            var ticketDto = _mapper?.Map<GetTicketDto>(ticket);

            if (ticket != null && ticketDto != null)
            {
                response.UpdateData(ticketDto);
            }

            return await Task.FromResult(response);
        }
    }
}
