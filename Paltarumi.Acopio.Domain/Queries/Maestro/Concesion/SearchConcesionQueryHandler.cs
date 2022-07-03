using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class SearchConcesionQueryHandler : SearchQueryHandlerBase<SearchConcesionQuery, SearchConcesionFilterDto, SearchConcesionDto>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public SearchConcesionQueryHandler(
            IMapper mapper,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(mapper)
        {
            _concesionRepository = concesionRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> HandleQuery(SearchConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchConcesionDto>>();

            Expression<Func<Entity.Concesion, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!String.IsNullOrEmpty(filters?.codigoOnombre))
                filter = filter.And(x => x.CodigoUnico.Contains(filters.codigoOnombre) || x.Nombre.Contains(filters.codigoOnombre));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var concesions = await _concesionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var concesionDtos = _mapper?.Map<IEnumerable<SearchConcesionDto>>(concesions.Items);

            var searchResult = new SearchResultDto<SearchConcesionDto>(
                concesionDtos ?? new List<SearchConcesionDto>(),
                concesions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
