using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class ListItemCheckQueryHandler : QueryHandlerBase<ListItemCheckQuery, IEnumerable<ListItemCheckDto>>
    {
        private readonly IRepositoryBase<Entity.ItemCheck> _repository;

        public ListItemCheckQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.ItemCheck> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListItemCheckDto>>> HandleQuery(ListItemCheckQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListItemCheckDto>>();
            var list = await _repository.FindByAsync(x => x.IdModulo == request.IdModulo && x.Activo == true);
            var listDtos = _mapper?.Map<IEnumerable<ListItemCheckDto>>(list);

            response.UpdateData(listDtos ?? new List<ListItemCheckDto>());

            return await Task.FromResult(response);
        }
    }
}
