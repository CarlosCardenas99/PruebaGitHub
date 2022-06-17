using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQueryHandler : SearchQueryHandlerBase<SearchTicketQuery, SearchTicketFilterDto, SearchTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public SearchTicketQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> HandleQuery(SearchTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTicketDto>>();

            Expression<Func<Entity.Ticket, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;
            //fechas
            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.FechaIngreso >= fechaDesde || x.FechaSalida >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechahasta = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.FechaIngreso < fechahasta || x.FechaSalida < fechahasta));
                }
            }
            //codigo
            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.Codigo.Contains(filters.Codigo));

            //proveedor
            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdLoteBalanzaNavigation.IdProveedorNavigation.Ruc.Contains(p) || x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            if (!string.IsNullOrEmpty(filters?.Concesion))
            {
                var concesiones = filters.Concesion.Split(" ");
                concesiones.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdLoteBalanzaNavigation.IdConcesionNavigation.CodigoUnico.Contains(p) || x.IdLoteBalanzaNavigation.IdConcesionNavigation.Nombre.Contains(p)));
                });
            }

            //vehiculo
            if (!string.IsNullOrEmpty(filters?.Vehiculo))
                filter = filter.And(x => x.IdVehiculoNavigation.Placa.Contains(filters.Vehiculo));

            //conductor
            if (!string.IsNullOrEmpty(filters?.Conductor))
                filter = filter.And(x => (x.IdConductorNavigation.Nombres.Contains(filters.Conductor)|| x.IdConductorNavigation.Licencia.Contains(filters.Conductor)));

            //tara
            if (filters?.TaraVehiculo > 0)
                filter = filter.And(x => x.Tara == filters.TaraVehiculo);

            //guias
            if (!string.IsNullOrEmpty(filters?.GuiasGR))
                filter = filter.And(x => (x.Grr.Contains(filters.GuiasGR) || x.Grt.Contains(filters.GuiasGR)));

            //activo
            filter = filter.And(x => x.Activo == true);

            var tickets = await _ticketRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdConductorNavigation,
                x => x.IdTransporteNavigation,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation,
                x => x.IdLoteBalanzaNavigation.IdProveedorNavigation,
                x => x.IdLoteBalanzaNavigation,
                x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation,
                x => x.IdEstadoTmhNavigation,
                x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation,
                x => x.IdLoteBalanzaNavigation.IdConcesionNavigation
            );

            var ticketDtos = _mapper?.Map<IEnumerable<SearchTicketDto>>(tickets.Items);

            var searchResult = new SearchResultDto<SearchTicketDto>(
                ticketDtos ?? new List<SearchTicketDto>(),
                tickets.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
