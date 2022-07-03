using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class SearchVehiculoQueryHandler : SearchQueryHandlerBase<SearchVehiculoQuery, SearchVehiculoFilterDto, SearchVehiculoDto>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public SearchVehiculoQueryHandler(
            IMapper mapper,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchVehiculoDto>>> HandleQuery(SearchVehiculoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchVehiculoDto>>();

            Expression<Func<Entity.Vehiculo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdVehiculo.HasValue == true)
                filter = filter.And(x => x.IdVehiculo == filters.IdVehiculo.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var vehiculos = await _vehiculoRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var vehiculoDtos = _mapper?.Map<IEnumerable<SearchVehiculoDto>>(vehiculos.Items);

            var searchResult = new SearchResultDto<SearchVehiculoDto>(
                vehiculoDtos ?? new List<SearchVehiculoDto>(),
                vehiculos.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
