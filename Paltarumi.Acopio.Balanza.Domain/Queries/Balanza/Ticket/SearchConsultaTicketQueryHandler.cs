using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchConsultaTicketQueryHandler : SearchQueryHandlerBase<SearchConsultaTicketQuery, SearchConsultaTicketFilterDto, SearchConsultaTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;

        public SearchConsultaTicketQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.LoteMuestreo> loteMuestreoRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> HandleQuery(SearchConsultaTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchConsultaTicketDto>>();

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
            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.CodigoLote.Contains(filters.CodigoLote));

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
                filter = filter.And(x => (x.IdConductorNavigation.Nombres.Contains(filters.Conductor) || x.IdConductorNavigation.Licencia.Contains(filters.Conductor)));

            //tara
            if (filters?.TaraVehiculo > 0)
                filter = filter.And(x => x.Tara == filters.TaraVehiculo);

            //guias
            if (!string.IsNullOrEmpty(filters?.GuiasGR))
            {
                var guias = filters.GuiasGR.Split(" ");
                guias.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.Grr.Contains(p) || x.Grt.Contains(p)));
                });
            }
            //if (!string.IsNullOrEmpty(filters?.GuiasGR))
            //    filter = filter.And(x => (x.Grr.Contains(filters.GuiasGR) || x.Grt.Contains(filters.GuiasGR)));

            //activo
            filter = filter.And(x => x.Activo == true);

            var sorts = new List<SortExpression<Entity.Ticket>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entity.Ticket>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var tickets = await _ticketRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
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
                x => x.IdLoteBalanzaNavigation.IdConcesionNavigation,
                x => x.IdEstadoTmhCarretaNavigation
            );
            var placas = tickets;

            var ticketDtos = _mapper?.Map<IEnumerable<SearchConsultaTicketDto>>(tickets.Items);

            var codigoLotes = ticketDtos?.Select(x => x.CodigoLote) ?? new List<string>();
            var loteMuestreos = await _loteMuestreoRepository.FindByAsNoTrackingAsync(x => codigoLotes.Contains(x.CodigoLote));

            if (ticketDtos != null)
                ticketDtos.ToList().ForEach(item =>
                {
                    var loteMuestreo = loteMuestreos.Where(x => x.CodigoLote.Equals(item.CodigoLote)).FirstOrDefault(new Entity.LoteMuestreo());
                    item.PorcentajeHumedad = loteMuestreo?.Humedad ?? 0;
                });

            var searchResult = new SearchResultDto<SearchConsultaTicketDto>(
                ticketDtos ?? new List<SearchConsultaTicketDto>(),
                tickets.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
