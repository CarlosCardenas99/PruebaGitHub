using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class ListDuenoMuestraQueryHandler : QueryHandlerBase<ListDuenoMuestraQuery, IEnumerable<ListDuenoMuestraDto>>
    {
        private readonly IRepository<Entity.DuenoMuestra> _repository;

        public ListDuenoMuestraQueryHandler(
            IMapper mapper,
            IRepository<Entity.DuenoMuestra> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListDuenoMuestraDto>>> HandleQuery(ListDuenoMuestraQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListDuenoMuestraDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListDuenoMuestraDto>>(list);

            response.UpdateData(listDtos ?? new List<ListDuenoMuestraDto>());

            return await Task.FromResult(response);
        }
    }
}
