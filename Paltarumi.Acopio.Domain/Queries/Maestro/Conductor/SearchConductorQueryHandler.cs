using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class SearchConductorQueryHandler : SearchQueryHandlerBase<SearchConductorQuery, ConductorFilterDto, ListConductorDto>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public SearchConductorQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(mapper)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<ListConductorDto>>> HandleQuery(SearchConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<ListConductorDto>>();

            Expression<Func<Entity.Conductor, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdConductor.HasValue == true)
                filter = filter.And(x => x.IdConductor == filters.IdConductor.Value);

            if (!string.IsNullOrEmpty(filters?.RazonSocial))
                filter = filter.And(x => x.RazonSocial.Contains(filters.RazonSocial));

            if (filters?.CodigosTipoDocumento != null && filters.CodigosTipoDocumento.Any())
                filter = filter.And(x => filters.CodigosTipoDocumento.Contains(x.CodigoTipoDocumento));

            if (!string.IsNullOrEmpty(filters?.Numero))
                filter = filter.And(x => x.Numero.Contains(filters.Numero));

            if (!string.IsNullOrEmpty(filters?.Licencia))
                filter = filter.And(x => x.Licencia.Contains(filters.Licencia));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var condutors = await _conductorRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var condutorDtos = _mapper?.Map<IEnumerable<ListConductorDto>>(condutors.Items);

            var searchResult = new SearchResultDto<ListConductorDto>(
                condutorDtos ?? new List<ListConductorDto>(),
                condutors.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
