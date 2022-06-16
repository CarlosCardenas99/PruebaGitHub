using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class SearchModuloQueryHandler : SearchQueryHandlerBase<SearchModuloQuery, SearchModuloFilterDto, SearchModuloDto>
    {
        private readonly IRepository<Entity.Modulo> _moduloRepository;

        public SearchModuloQueryHandler(
            IMapper mapper,
            IRepository<Entity.Modulo> moduloRepository
        ) : base(mapper)
        {
            _moduloRepository = moduloRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchModuloDto>>> HandleQuery(SearchModuloQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchModuloDto>>();

            Expression<Func<Entity.Modulo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdModulo.HasValue == true)
                filter = filter.And(x => x.IdModulo == filters.IdModulo.Value);

            var modulos = await _moduloRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var moduloDtos = _mapper?.Map<IEnumerable<SearchModuloDto>>(modulos.Items);

            var searchResult = new SearchResultDto<SearchModuloDto>(
                moduloDtos ?? new List<SearchModuloDto>(),
                modulos.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
