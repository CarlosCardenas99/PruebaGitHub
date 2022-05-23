using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class SearchLoteQueryHandler : SearchQueryHandlerBase<SearchLoteQuery, LoteFilterDto, ListLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public SearchLoteQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Lote> loteRepository
        ) : base(mapper)
        {
            _loteRepository = loteRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<ListLoteDto>>> HandleQuery(SearchLoteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<ListLoteDto>>();

            Expression<Func<Entity.Lote, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdLote.HasValue == true)
                filter = filter.And(x => x.IdLote == filters.IdLote.Value);

            if (filters?.IdConcesion.HasValue == true)
                filter = filter.And(x => x.IdConcesion == filters.IdConcesion.Value);

            if (filters?.IdProveedor.HasValue == true)
                filter = filter.And(x => x.IdProveedor == filters.IdProveedor.Value);

            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.Codigo.Contains(filters.Codigo));

            if (!string.IsNullOrEmpty(filters?.Vehiculos))
                filter = filter.And(x => x.Vehiculos.Contains(filters.Vehiculos));

            if (!string.IsNullOrEmpty(filters?.Transportistas))
                filter = filter.And(x => x.Transportistas.Contains(filters.Transportistas));

            if (!string.IsNullOrEmpty(filters?.Tickets))
                filter = filter.And(x => x.Tickets.Contains(filters.Tickets));

            if (!string.IsNullOrEmpty(filters?.Conductores))
                filter = filter.And(x => x.Conductores.Contains(filters.Conductores));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var lotes = await _loteRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdProveedorNavigation
            );

            var loteDtos = _mapper?.Map<IEnumerable<ListLoteDto>>(lotes.Items);

            var searchResult = new SearchResultDto<ListLoteDto>(
                loteDtos ?? new List<ListLoteDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
