using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion
{
    public class SearchProveedorConcesionQueryHandler : SearchQueryHandlerBase<SearchProveedorConcesionQuery, SearchProveedorConcesionFilterDto, SearchProveedorConcesionDto>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public SearchProveedorConcesionQueryHandler(
            IMapper mapper,
            IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(mapper)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> HandleQuery(SearchProveedorConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>();

            Expression<Func<Entity.ProveedorConcesion, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdProveedorConcesion.HasValue == true)
                filter = filter.And(x => x.IdProveedorConcesion == filters.IdProveedorConcesion.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var proveedorconcesions = await _proveedorconcesionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var proveedorconcesionDtos = _mapper?.Map<IEnumerable<SearchProveedorConcesionDto>>(proveedorconcesions.Items);

            var searchResult = new SearchResultDto<SearchProveedorConcesionDto>(
                proveedorconcesionDtos ?? new List<SearchProveedorConcesionDto>(),
                proveedorconcesions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
