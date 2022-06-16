using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
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
