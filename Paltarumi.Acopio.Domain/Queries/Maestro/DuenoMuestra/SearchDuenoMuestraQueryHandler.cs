using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class SearchDuenoMuestraQueryHandler : SearchQueryHandlerBase<SearchDuenoMuestraQuery, SearchDuenoMuestraFilterDto, SearchDuenoMuestraDto>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenomuestraRepository;

        public SearchDuenoMuestraQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(mapper)
        {
            _duenomuestraRepository = duenomuestraRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> HandleQuery(SearchDuenoMuestraQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>();

            Expression<Func<Entity.DuenoMuestra, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdDuenoMuestra.HasValue == true)
                filter = filter.And(x => x.IdDuenoMuestra == filters.IdDuenoMuestra.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var duenomuestras = await _duenomuestraRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var duenomuestraDtos = _mapper?.Map<IEnumerable<SearchDuenoMuestraDto>>(duenomuestras.Items);

            var searchResult = new SearchResultDto<SearchDuenoMuestraDto>(
                duenomuestraDtos ?? new List<SearchDuenoMuestraDto>(),
                duenomuestras.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
