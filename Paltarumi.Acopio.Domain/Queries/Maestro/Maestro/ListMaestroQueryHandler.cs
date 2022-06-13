using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class ListMaestroQueryHandler : QueryHandlerBase<ListMaestroQuery, IEnumerable<ListMaestroDto>>
    {
        private readonly IRepositoryBase<Entity.Maestro> _repository;

        public ListMaestroQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Maestro> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListMaestroDto>>> HandleQuery(ListMaestroQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListMaestroDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListMaestroDto>>(list);

            response.UpdateData(listDtos ?? new List<ListMaestroDto>());

            return await Task.FromResult(response);
        }
    }
}
