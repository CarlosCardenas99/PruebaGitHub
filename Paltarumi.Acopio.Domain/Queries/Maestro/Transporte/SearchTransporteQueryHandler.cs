using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class SearchTransporteQueryHandler : SearchQueryHandlerBase<SearchTransporteQuery, SearchTransporteFilterDto, SearchTransporteDto>
    {
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;

        public SearchTransporteQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Transporte> transporteRepository
        ) : base(mapper)
        {
            _transporteRepository = transporteRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> HandleQuery(SearchTransporteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTransporteDto>>();

            Expression<Func<Entity.Transporte, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdTransporte.HasValue == true)
                filter = filter.And(x => x.IdTransporte == filters.IdTransporte.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var transportes = await _transporteRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var transporteDtos = _mapper?.Map<IEnumerable<SearchTransporteDto>>(transportes.Items);

            var searchResult = new SearchResultDto<SearchTransporteDto>(
                transporteDtos ?? new List<SearchTransporteDto>(),
                transportes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
