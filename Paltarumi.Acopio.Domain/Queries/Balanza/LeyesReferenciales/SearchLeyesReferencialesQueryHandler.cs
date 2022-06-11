using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class SearchLeyesReferencialesQueryHandler : SearchQueryHandlerBase<SearchLeyesReferencialesQuery, LeyesReferencialesFilterDto, SearchLeyesReferencialesDto>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public SearchLeyesReferencialesQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository
        ) : base(mapper)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLeyesReferencialesDto>>> HandleQuery(SearchLeyesReferencialesQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLeyesReferencialesDto>>();

            Expression<Func<Entity.LeyesReferenciales, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdLeyesReferenciales.HasValue == true)
                filter = filter.And(x => x.IdLeyesReferenciales == filters.IdLeyesReferenciales.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var leyesreferencialess = await _leyesreferencialesRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var leyesreferencialesDtos = _mapper?.Map<IEnumerable<SearchLeyesReferencialesDto>>(leyesreferencialess.Items);

            var searchResult = new SearchResultDto<SearchLeyesReferencialesDto>(
                leyesreferencialesDtos ?? new List<SearchLeyesReferencialesDto>(),
                leyesreferencialess.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
