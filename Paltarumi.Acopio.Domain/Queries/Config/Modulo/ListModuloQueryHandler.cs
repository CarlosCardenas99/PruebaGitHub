using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class ListModuloQueryHandler : QueryHandlerBase<ListModuloQuery, IEnumerable<ListModuloDto>>
    {
        private readonly IRepositoryBase<Entity.Modulo> _repository;

        public ListModuloQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Modulo> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListModuloDto>>> HandleQuery(ListModuloQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListModuloDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListModuloDto>>(list);

            response.UpdateData(listDtos ?? new List<ListModuloDto>());

            return await Task.FromResult(response);
        }
    }
}
