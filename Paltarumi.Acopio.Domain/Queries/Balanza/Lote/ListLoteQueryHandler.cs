using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class ListLoteQueryHandler : QueryHandlerBase<ListLoteQuery, IEnumerable<ListLoteDto>>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public ListLoteQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Lote> loteRepository
        ) : base(mapper)
        {
            _loteRepository = loteRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteDto>>> HandleQuery(ListLoteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteDto>>();
            var lotes = await _loteRepository.FindAll().ToListAsync(cancellationToken);
            var loteDtos = _mapper?.Map<IEnumerable<ListLoteDto>>(lotes);

            response.UpdateData(loteDtos ?? new List<ListLoteDto>());

            return await Task.FromResult(response);
        }
    }
}
