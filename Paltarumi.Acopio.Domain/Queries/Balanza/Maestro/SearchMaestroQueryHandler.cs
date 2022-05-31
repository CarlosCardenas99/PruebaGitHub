using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class SearchMaestroQueryHandler : SearchQueryHandlerBase<SearchMaestroQuery, MaestroFilterDto, SearchMaestroDto>
    {
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;

        public SearchMaestroQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Maestro> maestroRepository
        ) : base(mapper)
        {
            _maestroRepository = maestroRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> HandleQuery(SearchMaestroQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchMaestroDto>>();

            Expression<Func<Entity.Maestro, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.Activo == true)
                filter = filter.And(x => x.Activo == filters.Activo);

            var maestros = await _maestroRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var maestroDtos = _mapper?.Map<IEnumerable<SearchMaestroDto>>(maestros.Items);

            var searchResult = new SearchResultDto<SearchMaestroDto>(
                maestroDtos ?? new List<SearchMaestroDto>(),
                maestros.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
