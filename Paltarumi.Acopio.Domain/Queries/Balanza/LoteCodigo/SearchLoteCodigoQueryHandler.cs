using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class SearchLoteCodigoQueryHandler : SearchQueryHandlerBase<SearchLoteCodigoQuery, LoteCodigoFilterDto, SearchLoteCodigoDto>
    {
        private readonly IRepositoryBase<Entity.LoteCodigo> _lotecodigoRepository;

        public SearchLoteCodigoQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LoteCodigo> lotecodigoRepository
        ) : base(mapper)
        {
            _lotecodigoRepository = lotecodigoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> HandleQuery(SearchLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteCodigoDto>>();

            Expression<Func<Entity.LoteCodigo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdLoteCodigo.HasValue == true)
                filter = filter.And(x => x.IdLoteCodigo == filters.IdLoteCodigo.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var lotecodigos = await _lotecodigoRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var lotecodigoDtos = _mapper?.Map<IEnumerable<SearchLoteCodigoDto>>(lotecodigos.Items);

            var searchResult = new SearchResultDto<SearchLoteCodigoDto>(
                lotecodigoDtos ?? new List<SearchLoteCodigoDto>(),
                lotecodigos.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
