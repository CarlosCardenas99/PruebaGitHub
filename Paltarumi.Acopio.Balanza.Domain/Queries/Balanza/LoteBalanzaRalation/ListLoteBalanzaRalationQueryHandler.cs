using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class ListLoteBalanzaRalationQueryHandler : QueryHandlerBase<ListLoteBalanzaRalationQuery, IEnumerable<ListLoteBalanzaRalationDto>>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _repository;

        public ListLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteBalanzaRalation> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>> HandleQuery(ListLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListLoteBalanzaRalationDto>>(list);

            response.UpdateData(listDtos ?? new List<ListLoteBalanzaRalationDto>());

            return await Task.FromResult(response);
        }
    }
}
