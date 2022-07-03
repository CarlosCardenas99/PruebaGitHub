using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQueryHandler : SearchQueryHandlerBase<SearchLoteCodigoQuery, SearchLoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public SearchLoteCodigoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(mapper)
        {
            _lotecodigoRepository = lotecodigoRepository;
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

            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.Codigo.Contains(filters.Codigo));

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                filter = filter.And(x =>
                (x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial.Contains(filters.Proveedor) || x.IdLoteBalanzaNavigation.IdProveedorNavigation.Ruc.Contains(filters.Proveedor)));
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
                x => x.IdLoteBalanzaNavigation,
                x => x.IdLoteBalanzaNavigation.IdEstadoNavigation,
                x => x.IdLoteBalanzaNavigation.IdProveedorNavigation
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