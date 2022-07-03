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
    public class SearchMaestroQueryHandler : SearchQueryHandlerBase<SearchMaestroQuery, SearchMaestroFilterDto, SearchMaestroDto>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;

        public SearchMaestroQueryHandler(
            IMapper mapper,
            IRepository<Entity.Maestro> maestroRepository
        ) : base(mapper)
        {
            _maestroRepository = maestroRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> HandleQuery(SearchMaestroQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchMaestroDto>>();

            Expression<Func<Entity.Maestro, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!string.IsNullOrEmpty(filters?.Descripcion))
                filter = filter.And(x => x.Descripcion.Contains(filters.Descripcion));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            filter = filter.And(x => x.CodigoItem.Equals(Constants.Maestro.TABLA_CODIGO_ITEM));

            var maestros = await _maestroRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var maestroDtos = _mapper?.Map<IEnumerable<SearchMaestroDto>>(maestros.Items);

            var searchResult = new SearchResultDto<SearchMaestroDto>(
                maestroDtos ?? new List<SearchMaestroDto>(),
                maestros.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
