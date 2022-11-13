using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class GetLoteBalanzaRalationQueryHandler : QueryHandlerBase<GetLoteBalanzaRalationQuery, GetLoteBalanzaRalationDto>
    {
        private readonly IRepository<Entity.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public GetLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            GetLoteBalanzaRalationQueryValidator validator,
            IRepository<Entity.LoteBalanzaRalation> lotebalanzaralationRepository
        ) : base(mapper, validator)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
        }

        protected override async Task<ResponseDto<GetLoteBalanzaRalationDto>> HandleQuery(GetLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaRalationDto>();
            var lotebalanzaralation = await _lotebalanzaralationRepository.GetByAsync(x => x.IdLoteBalanzaRalation == request.Id);
            var lotebalanzaralationDto = _mapper?.Map<GetLoteBalanzaRalationDto>(lotebalanzaralation);

            if (lotebalanzaralation != null && lotebalanzaralationDto != null)
            {
                response.UpdateData(lotebalanzaralationDto);
            }

            return await Task.FromResult(response);
        }
    }
}
