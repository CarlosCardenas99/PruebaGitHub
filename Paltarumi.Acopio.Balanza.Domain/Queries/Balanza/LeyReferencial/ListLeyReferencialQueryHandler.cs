using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial
{
    public class ListLeyReferencialQueryHandler : QueryHandlerBase<ListLeyReferencialQuery, IEnumerable<ListLeyReferencialDto>>
    {
        private readonly IRepository<Entities.LeyReferencial> _repository;

        public ListLeyReferencialQueryHandler(
            IMapper mapper,
            IRepository<Entities.LeyReferencial> repository
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
