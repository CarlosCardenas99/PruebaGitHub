using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByIdQueryHandler : QueryHandlerBase<GetTicketByIdQuery, GetTicketByIdDto>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public GetTicketByIdQueryHandler(
            IMapper mapper,
            GetTicketByIdQueryValidator validator,
            IRepository<Entities.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<GetTicketByIdDto>> HandleQuery(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketByIdDto>();
            var ticket = await _ticketRepository.GetByAsync(
                x => x.IdTicket == request.IdTicket ,
                x => x.IdConductorNavigation,
                x => x.IdLoteBalanzaNavigation.IdProveedorNavigation


               
                );
            var ticketDto = _mapper?.Map<GetTicketByIdDto>(ticket);

            response.UpdateData(ticketDto);
            return await Task.FromResult(response);
        }


    }
}
