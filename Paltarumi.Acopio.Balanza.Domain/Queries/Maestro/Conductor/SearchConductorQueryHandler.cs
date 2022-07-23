using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class SearchConductorQueryHandler : SearchQueryHandlerBase<SearchConductorQuery, SearchConductorFilterDto, SearchConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public SearchConductorQueryHandler(
            IMapper mapper,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(mapper)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchConductorDto>>> HandleQuery(SearchConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchConductorDto>>();

            Expression<Func<Entity.Conductor, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdConductor.HasValue == true)
                filter = filter.And(x => x.IdConductor == filters.IdConductor.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var conductors = await _conductorRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdTipoLicenciaNavigation
            );

            var conductorDtos = _mapper?.Map<IEnumerable<SearchConductorDto>>(conductors.Items);

            var searchResult = new SearchResultDto<SearchConductorDto>(
                conductorDtos ?? new List<SearchConductorDto>(),
                conductors.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
