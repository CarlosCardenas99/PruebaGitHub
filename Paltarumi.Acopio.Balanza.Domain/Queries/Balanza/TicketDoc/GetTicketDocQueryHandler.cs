using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class GetTicketDocQueryHandler : QueryHandlerBase<GetTicketDocQuery, GetTicketDocDto>
    {
        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public GetTicketDocQueryHandler(
            IMapper mapper,
            GetTicketDocQueryValidator validator,
            IRepository<Entity.TicketDoc> ticketdocRepository
        ) : base(mapper, validator)
        {
            _ticketdocRepository = ticketdocRepository;
        }

        protected override async Task<ResponseDto<GetTicketDocDto>> HandleQuery(GetTicketDocQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDocDto>();
            var ticketdoc = await _ticketdocRepository.GetByAsync(x => x.IdTicketDoc == request.Id);
            var ticketdocDto = _mapper?.Map<GetTicketDocDto>(ticketdoc);

            if (ticketdoc != null && ticketdocDto != null)
            {
                response.UpdateData(ticketdocDto);
            }

            return await Task.FromResult(response);
        }
    }
}
