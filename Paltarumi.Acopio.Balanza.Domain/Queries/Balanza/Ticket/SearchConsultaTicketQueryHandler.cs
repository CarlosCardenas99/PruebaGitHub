using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using Paltarumi.Acopio.Repository.Security;
using System.Linq.Expressions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchConsultaTicketQueryHandler : SearchQueryHandlerBase<SearchConsultaTicketQuery, SearchConsultaTicketFilterDto, SearchConsultaTicketDto>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;
        private readonly IRepository<Entities.LoteMuestreo> _loteMuestreoRepository;
        private readonly IUserIdentity _userIdentity;

        public SearchConsultaTicketQueryHandler(
            IMapper mapper,
            IRepository<Entities.Ticket> ticketRepository,
            IRepository<Entities.LoteMuestreo> loteMuestreoRepository,
            IUserIdentity userIdentity
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
            _loteMuestreoRepository = loteMuestreoRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> HandleQuery(SearchConsultaTicketQuery request, CancellationToken cancellationToken)
        {
            var idSucursal = _userIdentity.GetIdSucursal();

            var response = new ResponseDto<SearchResultDto<SearchConsultaTicketDto>>();

            Expression<Func<Entities.Ticket, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            filter = filtrarFechas(filters, filter);
            filter = filtrarCodigoLote(filters, filter);
            filter = filtrarProveedor(filters, filter);
            filter = filtrarConcesion(filters, filter);
            filter = filtrarVehiculo(filters, filter);
            filter = filtrarConductor(filters, filter);
            filter = filtrarTara(filters, filter);
            filter = guiaRemisionRemitente(filters, filter);
            filter = guiaRemisionTransportista(filters, filter);
            filter = filtrarTransportista(filters, filter);
            filter = filtrarEstadoLote(filters, filter);

            //filter = filter.And(x => x.Activo == true);
            filter = filter.And(x => x.Activo == filters.Activo);

            if (!string.IsNullOrEmpty(idSucursal))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.IdCorrelativoNavigation.IdSucursal == idSucursal);


            var sorts = new List<SortExpression<Entities.Ticket>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entities.Ticket>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var tickets = await _ticketRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdConductorNavigation!,
                x => x.IdConductorNavigation!.IdTipoLicenciaNavigation!,
                x => x.IdTransporteNavigation!,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation,
                x => x.IdLoteBalanzaNavigation.IdLoteEstadoNavigation,
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
                    var loteMuestreo = loteMuestreos.Where(x => x.CodigoLote.Equals(item.CodigoLote)).FirstOrDefault(new Entities.LoteMuestreo());
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

        private Expression<Func<Entities.Ticket, bool>> filtrarFechas(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.GetStartDate();
                    filter = filter.And(x => (x.FechaIngreso >= fechaDesde || x.FechaSalida >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechahasta = filters.FechaHasta.GetEndDate();
                    filter = filter.And(x => (x.FechaIngreso < fechahasta || x.FechaSalida < fechahasta));
                }
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarCodigoLote(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.CodigoLote.Contains(filters.CodigoLote));

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarProveedor(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdLoteBalanzaNavigation.IdProveedorNavigation.Ruc.Contains(p) || x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarConcesion(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (!string.IsNullOrEmpty(filters?.Concesion))
            {
                var concesiones = filters.Concesion.Split(" ");
                concesiones.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdLoteBalanzaNavigation.IdConcesionNavigation.CodigoUnico.Contains(p) || x.IdLoteBalanzaNavigation.IdConcesionNavigation.Nombre.Contains(p)));
                });
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarVehiculo(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.VehiculoVacio == true)
                filter = filter.And(x => x.IdConductor.Value == null);
            else
            {
                if (!string.IsNullOrEmpty(filters?.Vehiculo))
                {
                    filters.Vehiculo = filters.Vehiculo.ToUpper();
                    if (filters.Vehiculo.Length == 6) filters.Vehiculo = filters.Vehiculo.Insert(3, "-");

                    filter = filter.And(x => x.IdVehiculoNavigation.Placa.Contains(filters.Vehiculo) || x.IdVehiculoNavigation.PlacaCarreta.Contains(filters.Vehiculo));
                }
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarConductor(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.ConductorVacio == true)
                filter = filter.And(x => x.IdConductor.Value == null);
            else
            {
                if (!string.IsNullOrEmpty(filters?.Conductor))
                    filter = filter.And(x => (x.IdConductorNavigation.Nombres.Contains(filters.Conductor) || x.IdConductorNavigation.Licencia.Contains(filters.Conductor) || x.IdConductorNavigation.Numero.Contains(filters.Conductor)));
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarTara(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.TaraInicial > 0 || filters?.TaraFinal > 0)
            {
                if (filters?.TaraInicial > 0)
                {
                    var taraInicial = filters.TaraInicial;
                    filter = filter.And(x => x.Tara >= taraInicial);
                }

                if (filters?.TaraFinal > 0)
                {
                    var taraFinal = filters.TaraFinal;
                    filter = filter.And(x => x.Tara <= taraFinal);
                }
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> guiaRemisionRemitente(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.GuiaRemisionRemitenteVacio == true)
                filter = filter.And(x => x.Grr == string.Empty);
            else
            {
                if (!string.IsNullOrEmpty(filters?.GuiaRemisionRemitente))
                {
                    var guias = filters.GuiaRemisionRemitente.Split(" ");
                    guias.ToList().ForEach(p =>
                    {
                        filter = filter.And(x =>
                        (x.Grr.Contains(p)));
                    });
                }
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> guiaRemisionTransportista(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.GuiaRemisionTransportistaVacio == true)
                filter = filter.And(x => x.Grt == string.Empty);
            else
            {
                if (!string.IsNullOrEmpty(filters?.GuiaRemisionTransportista))
                {
                    var guias = filters.GuiaRemisionTransportista.Split(" ");
                    guias.ToList().ForEach(p =>
                    {
                        filter = filter.And(x =>
                        (x.Grt.Contains(p)));
                    });
                }
            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarTransportista(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (filters?.TransporteVacio == true)
                filter = filter.And(x => x.IdTransporte.Value == null);
            else
            {
                if (!string.IsNullOrEmpty(filters?.Transporte))
                    filter = filter.And(x => (x.IdTransporteNavigation!.Ruc.Contains(filters.Transporte) || x.IdTransporteNavigation.RazonSocial.Contains(filters.Transporte)));

            }

            return filter;
        }
        private Expression<Func<Entities.Ticket, bool>> filtrarEstadoLote(SearchConsultaTicketFilterDto? filters, Expression<Func<Entities.Ticket, bool>> filter)
        {
            if (!string.IsNullOrEmpty(filters?.IdLoteEstado))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.IdLoteEstado == filters.IdLoteEstado);

            return filter;
        }

    }
}
