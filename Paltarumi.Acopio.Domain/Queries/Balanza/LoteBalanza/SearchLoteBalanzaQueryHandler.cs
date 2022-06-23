using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class SearchLoteBalanzaQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaQuery, SearchLoteBalanzaFilterDto, SearchLoteBalanzaDto>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public SearchLoteBalanzaQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
             IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> HandleQuery(SearchLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>();

            Expression<Func<Entity.LoteBalanza, bool>> filter = x => true;

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

            if (filters?.idEstado.HasValue == true)
                filter = filter.And(x => x.IdEstado == filters.idEstado);

            if (!string.IsNullOrEmpty(filters?.Vehiculos))
                filter = filter.And(x => x.Tickets.Any(x => x.IdVehiculoNavigation.Placa.Contains(filters.Vehiculos)));

            if (!string.IsNullOrEmpty(filters?.NumeroTickets))
                filter = filter.And(x => x.Tickets.Any(x => x.Numero.Contains(filters.NumeroTickets)));

            var sorts = new List<SortExpression<Entity.LoteBalanza>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entity.LoteBalanza>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var lotes = await _loteBalanzaRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation,
                x => x.IdEstadoTipoMaterialNavigation,
                x => x.Tickets,
                x => x.IdEstadoNavigation
            );

            var tickets = new List<Entity.Ticket>();

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(x => tickets.AddRange(x.Tickets));

            var vehículoIds = tickets.Select(x => x.IdVehiculo);
            var vehículos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => vehículoIds.Contains(x.IdVehiculo));

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(item =>
                {
                    var ids = item.Tickets.Select(x => x.IdVehiculo);
                    var vehicles = vehículos.Where(x => ids.Contains(x.IdVehiculo)).Select(x => x.Placa);
                    item.Vehiculos = string.Join(",", vehicles);
                });

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteBalanzaDto>>(lotes.Items);

            var searchResult = new SearchResultDto<SearchLoteBalanzaDto>(
                loteDtos ?? new List<SearchLoteBalanzaDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
