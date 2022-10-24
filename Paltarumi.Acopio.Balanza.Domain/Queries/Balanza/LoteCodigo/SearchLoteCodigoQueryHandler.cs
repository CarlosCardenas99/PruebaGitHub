using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Entity;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Security;
using Paltarumi.Acopio.Dto.Base;
using System.Linq.Expressions;
using Telerik.Reporting.Processing;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQueryHandler : SearchQueryHandlerBase<SearchLoteCodigoQuery, SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IUserIdentity _userIdentity;

        public SearchLoteCodigoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCodigo> lotecodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IUserIdentity userIdentity
        ) : base(mapper)
        {
            _lotecodigoRepository = lotecodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> HandleQuery(SearchLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var idSucursal = "02"; //_userIdentity.GetIdSucursal();
            var response = new ResponseDto<SearchResultDto<SearchLoteCodigoDto>>();

            Expression<Func<Entity.LoteCodigo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.GetStartDate();
                    filter = filter.And(x => (x.FechaRecepcion >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.GetEndDate();
                    filter = filter.And(x => (x.FechaRecepcion < fechaHasta));
                }
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.IdLoteNavigation!.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var loteBalanzasProv = _loteBalanzaRepository.FindByAsNoTrackingAsync(
                    x => (x.IdProveedorNavigation.RazonSocial.Contains(filters.Proveedor) || x.IdProveedorNavigation.Ruc.Contains(filters.Proveedor)),
                    x => x.IdProveedorNavigation
                );

                var CodigoLotesProv = loteBalanzasProv.Result.Select(x => x.CodigoLote).ToList();

                filter = filter.And(x => CodigoLotesProv.Contains(x.IdLoteNavigation!.CodigoLote));
            }
            if (!string.IsNullOrEmpty(idSucursal))
                filter = filter.And(x => x.IdCorrelativoNavigation!.IdSucursal == idSucursal);

            var sorts = new List<SortExpression<Entity.LoteCodigo>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entity.LoteCodigo>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var lotes = await _lotecodigoRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdLoteNavigation!,
                x => x.IdLoteCodigoEstadoNavigation,
                x => x.IdDuenoMuestraNavigation!,
                x => x.IdProveedorNavigation!
            );

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteCodigoDto>>(lotes.Items);

            var searchResult = new SearchResultDto<SearchLoteCodigoDto>(
                loteDtos ?? new List<SearchLoteCodigoDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
/*if (!string.IsNullOrEmpty(idSucursal))
            {
                var loteBalanzasBySucursal = _loteBalanzaRepository.FindByAsNoTrackingAsync(
                    x => x.IdCorrelativoNavigation.IdSucursal.Contains(idSucursal),
                    x => x.IdCorrelativoNavigation
                );

                var CodigoLotesBySucursal = loteBalanzasBySucursal.Result.Select(x => x.CodigoLote).ToList() ?? new List<string>();

                filter = filter.And(x => CodigoLotesBySucursal.Contains(x.IdLoteNavigation!.CodigoLote) || x.IdLote == null);
            }*/