using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class SearchLoteQueryHandler : SearchQueryHandlerBase<SearchLoteQuery, LoteFilterDto, SearchLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;

        public SearchLoteQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Lote> loteRepository,
             IRepositoryBase<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _loteRepository = loteRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteDto>>> HandleQuery(SearchLoteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteDto>>();

            Expression<Func<Entity.Lote, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.FechaAcopio >= fechaDesde || x.FechaIngreso >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaDesde = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.FechaAcopio < fechaDesde || x.FechaIngreso < fechaDesde));
                }
            }

            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.Codigo.Contains(filters.Codigo));

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdProveedorNavigation.Ruc.Contains(p) || x.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            if (filters?.CodigoEstado.HasValue == true)
                filter = filter.And(x => x.CodigoEstado == filters.CodigoEstado);

            if (!string.IsNullOrEmpty(filters?.Vehiculos))
                filter = filter.And(x => x.TicketsNavigation.Any(x => x.IdVehiculoNavigation.Placa.Contains(filters.Vehiculos)));

            if (!string.IsNullOrEmpty(filters?.Tickets))
                filter = filter.And(x => x.TicketsNavigation.Any(x => x.Numero.Contains(filters.Tickets)));

            var lotes = await _loteRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation,
                x => x.IdEstadoTipoMaterialNavigation,
                x => x.TicketsNavigation
            );

            var tickets = new List<Entity.Ticket>();

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(x => tickets.AddRange(x.TicketsNavigation));

            var vehículoIds = tickets.Select(x => x.IdVehiculo);
            var vehículos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => vehículoIds.Contains(x.IdVehiculo));

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(item =>
                {
                    var ids = item.TicketsNavigation.Select(x => x.IdVehiculo);
                    var vehicles = vehículos.Where(x => ids.Contains(x.IdVehiculo)).Select(x => x.Placa);
                    item.Vehiculos = string.Join(",", vehicles);
                });

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteDto>>(lotes.Items);

            var searchResult = new SearchResultDto<SearchLoteDto>(
                loteDtos ?? new List<SearchLoteDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
