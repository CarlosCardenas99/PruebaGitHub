using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Security;
using Paltarumi.Acopio.Dto.Base;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class SearchLoteBalanzaQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaQuery, SearchLoteBalanzaFilterDto, SearchLoteBalanzaDto>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        private readonly IUserIdentity _userIdentity;

        public SearchLoteBalanzaQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IUserIdentity userIdentity
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> HandleQuery(SearchLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var idSucursal = _userIdentity.GetIdSucursal();

            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>();

            Expression<Func<Entity.LoteBalanza, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.GetStartDate();
                    filter = filter.And(x => (x.FechaAcopio >= fechaDesde || x.FechaIngreso >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.GetEndDate();
                    filter = filter.And(x => (x.FechaAcopio < fechaHasta || x.FechaIngreso < fechaHasta));
                }
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdProveedorNavigation.Ruc.Contains(p) || x.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            if (!string.IsNullOrEmpty(filters?.IdLoteEstado))
                filter = filter.And(x => x.IdLoteEstado == filters.IdLoteEstado);

            if (!string.IsNullOrEmpty(filters?.Vehiculos))
                filter = filter.And(x => x.Tickets.Any(x => x.IdVehiculoNavigation.Placa.Contains(filters.Vehiculos)));

            if (!string.IsNullOrEmpty(filters?.NumeroTickets))
                filter = filter.And(x => x.Tickets.Any(x => x.Numero.Contains(filters.NumeroTickets)));

            if (!string.IsNullOrEmpty(idSucursal))
                filter = filter.And(x => x.IdCorrelativoNavigation.IdSucursal == idSucursal);

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
                x => x.Tickets.Where(x =>x.Activo==true),
                x => x.IdLoteEstadoNavigation,
                x => x.IdCorrelativoNavigation
            );

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
