using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class ListLeyReferencialQueryHandler : QueryHandlerBase<ListLeyReferencialQuery, IEnumerable<ListLeyReferencialDto>>
    {
        private readonly IRepository<Entity.LeyReferencial> _repository;

        public ListLeyReferencialQueryHandler(
            IMapper mapper,
            IRepository<Entity.LeyReferencial> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLeyReferencialDto>>> HandleQuery(ListLeyReferencialQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLeyReferencialDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListLeyReferencialDto>>(list);

            response.UpdateData(listDtos ?? new List<ListLeyReferencialDto>());

            return await Task.FromResult(response);
        }
    }
}
