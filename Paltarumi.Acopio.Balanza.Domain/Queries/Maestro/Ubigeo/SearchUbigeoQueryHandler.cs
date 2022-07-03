using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Ubigeo;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Ubigeo
{
    public class SearchUbigeoQueryHandler : SearchQueryHandlerBase<SearchUbigeoQuery, UbigeoFilterDto, SearchUbigeoDto>
    {
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepository;

        public SearchUbigeoQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ubigeo> ubigeoRepository
        ) : base(mapper)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchUbigeoDto>>> HandleQuery(SearchUbigeoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchUbigeoDto>>();

            Expression<Func<Entity.Ubigeo, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!string.IsNullOrEmpty(filters?.CodigoUbigeo))
                filter = filter.And(x => x.CodigoUbigeo == filters.CodigoUbigeo);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var ubigeos = await _ubigeoRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var ubigeoDtos = _mapper?.Map<IEnumerable<SearchUbigeoDto>>(ubigeos.Items);

            var searchResult = new SearchResultDto<SearchUbigeoDto>(
                ubigeoDtos ?? new List<SearchUbigeoDto>(),
                ubigeos.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
