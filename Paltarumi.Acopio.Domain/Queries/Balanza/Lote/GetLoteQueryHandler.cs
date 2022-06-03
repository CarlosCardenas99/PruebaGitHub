using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class GetLoteQueryHandler : QueryHandlerBase<GetLoteQuery, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public GetLoteQueryHandler(
            IMapper mapper,
            GetLoteQueryValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository
        ) : base(mapper, validator)
        {
            _loteRepository = loteRepository;
        }

        protected override async Task<ResponseDto<GetLoteDto>> HandleQuery(GetLoteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = await _loteRepository.GetByAsync(x => x.IdLote == request.Id, x => x.Tickets);
            var loteDto = _mapper?.Map<GetLoteDto>(lote);

            if (lote != null && loteDto != null)
            {
                loteDto.TicketDetails = _mapper?.Map<IEnumerable<GetTicketDto>>(lote.Tickets);
                response.UpdateData(loteDto);
            }

            return await Task.FromResult(response);
        }
    }
}
