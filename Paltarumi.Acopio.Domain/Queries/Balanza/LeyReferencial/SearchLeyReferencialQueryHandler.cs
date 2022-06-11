using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class SearchLeyReferencialQueryHandler : SearchQueryHandlerBase<SearchLeyReferencialQuery, SearchLeyReferencialFilterDto, SearchLeyReferencialDto>
    {
        private readonly IRepositoryBase<Entity.LeyReferencial> _leyreferencialRepository;

        public SearchLeyReferencialQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LeyReferencial> leyreferencialRepository
        ) : base(mapper)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> HandleQuery(SearchLeyReferencialQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLeyReferencialDto>>();

            Expression<Func<Entity.LeyReferencial, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.FechaRecepcion >= fechaDesde || x.FechaRecepcion >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaDesde = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.FechaRecepcion < fechaDesde || x.FechaRecepcion < fechaDesde));
                }
            }
            filter = filter.And(x => x.Activo == true);

            if ( !string.IsNullOrEmpty(filters?.Dueno) )
                filter = filter.And(x => x.IdDuenoMuestraNavigation.Nombres.Contains(filters.Dueno));

            var leyreferencials = await _leyreferencialRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdDuenoMuestraNavigation,
                x => x.IdTipoMineralNavigation
            );

            var leyreferencialDtos = _mapper?.Map<IEnumerable<SearchLeyReferencialDto>>(leyreferencials.Items);

            var searchResult = new SearchResultDto<SearchLeyReferencialDto>(
                leyreferencialDtos ?? new List<SearchLeyReferencialDto>(),
                leyreferencials.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
