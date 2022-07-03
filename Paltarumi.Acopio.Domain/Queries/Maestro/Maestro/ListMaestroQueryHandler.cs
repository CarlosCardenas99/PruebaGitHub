using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class ListMaestroQueryHandler : QueryHandlerBase<ListMaestroQuery, IEnumerable<ListMaestroDto>>
    {
        private readonly IRepository<Entity.Maestro> _repository;

        public ListMaestroQueryHandler(
            IMapper mapper,
            IRepository<Entity.Maestro> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListMaestroDto>>> HandleQuery(ListMaestroQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Entity.Maestro, bool>> filter = x => true;

            var filters = request;

            if (!string.IsNullOrEmpty(filters?.CodigoTabla))
                filter = filter.And(x => x.CodigoTabla.Equals(request.CodigoTabla));

            filter = filter.And(x => x.Activo == true);
            filter = filter.And(x => !x.CodigoItem.Equals(Constants.Maestro.TABLA_CODIGO_ITEM));

            var response = new ResponseDto<IEnumerable<ListMaestroDto>>();

            var list = await _repository.FindByAsync(filter);

            var listDtos = _mapper?.Map<IEnumerable<ListMaestroDto>>(list);

            response.UpdateData(listDtos ?? new List<ListMaestroDto>());

            return await Task.FromResult(response);
        }
    }
}
