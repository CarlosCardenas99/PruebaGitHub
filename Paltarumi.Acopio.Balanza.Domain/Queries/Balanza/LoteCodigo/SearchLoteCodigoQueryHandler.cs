using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQueryHandler : SearchQueryHandlerBase<SearchLoteCodigoQuery, SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        public SearchLoteCodigoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCodigo> lotecodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository
        ) : base(mapper)
        {
            _lotecodigoRepository = lotecodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> HandleQuery(SearchLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteCodigoDto>>();

            Expression<Func<Entity.LoteCodigo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.FechaRecepcion >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.FechaRecepcion < fechaHasta));
                }
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.IdLoteNavigation.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var loteBalanzasProv = _loteBalanzaRepository.FindByAsNoTrackingAsync(
                    x => (x.IdProveedorNavigation.RazonSocial.Contains(filters.Proveedor) || x.IdProveedorNavigation.Ruc.Contains(filters.Proveedor)),
                    x => x.IdProveedorNavigation
                );

                var CodigoLotesProv = loteBalanzasProv.Result.Select(x => x.CodigoLote).ToList();

                filter = filter.And(x => CodigoLotesProv.Contains(x.IdLoteNavigation.CodigoLote));
            }

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
                x => x.IdLoteNavigation
            );

            var codigoLotes = lotes.Items.Select(x => x.IdLoteNavigation == null ? string.Empty : x.IdLoteNavigation.CodigoLote).ToList();

            var loteBalanzas = _loteBalanzaRepository.FindByAsNoTrackingAsync(
                x => codigoLotes.Contains(x.CodigoLote),
                x => x.IdEstadoNavigation,
                x => x.IdProveedorNavigation
            );

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteCodigoDto>>(lotes.Items);

            loteDtos.ToList().ForEach(item =>
            {
                var loteBalanza = loteBalanzas.Result.Where(x => x.CodigoLote == item.loteCodigo).FirstOrDefault(new Entity.LoteBalanza());
                if(loteBalanza.IdLoteBalanza > 0)
                {
                    item.Proveedor = loteBalanza.IdProveedorNavigation.RazonSocial;
                    item.Estado = loteBalanza.IdEstadoNavigation.Descripcion;
                }
            });

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