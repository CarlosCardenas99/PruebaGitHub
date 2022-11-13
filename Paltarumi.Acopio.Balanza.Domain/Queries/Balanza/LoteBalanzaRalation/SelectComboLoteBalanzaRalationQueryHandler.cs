using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class SelectComboLoteBalanzaRalationQueryHandler : QueryHandlerBase<SelectComboLoteBalanzaRalationQuery, IEnumerable<SelectComboLoteBalanzaRalationDto>>
    {
        private readonly IRepository<Entity.LoteBalanzaRalation> _repository;

        public SelectComboLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteBalanzaRalation> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<SelectComboLoteBalanzaRalationDto>>> HandleQuery(SelectComboLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<SelectComboLoteBalanzaRalationDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<SelectComboLoteBalanzaRalationDto>>(list);

            response.UpdateData(listDtos ?? new List<SelectComboLoteBalanzaRalationDto>());

            return await Task.FromResult(response);
        }
    }
}
