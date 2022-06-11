using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class SearchRecodificacionQueryHandler : SearchQueryHandlerBase<SearchRecodificacionQuery, SearchRecodificacionFilterDto, SearchRecodificacionDto>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public SearchRecodificacionQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Recodificacion> recodificacionRepository
        ) : base(mapper)
        {
            _recodificacionRepository = recodificacionRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchRecodificacionDto>>> HandleQuery(SearchRecodificacionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchRecodificacionDto>>();

            Expression<Func<Entity.Recodificacion, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdRecodificacion.HasValue == true)
                filter = filter.And(x => x.IdRecodificacion == filters.IdRecodificacion.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var recodificacions = await _recodificacionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var recodificacionDtos = _mapper?.Map<IEnumerable<SearchRecodificacionDto>>(recodificacions.Items);

            var searchResult = new SearchResultDto<SearchRecodificacionDto>(
                recodificacionDtos ?? new List<SearchRecodificacionDto>(),
                recodificacions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
