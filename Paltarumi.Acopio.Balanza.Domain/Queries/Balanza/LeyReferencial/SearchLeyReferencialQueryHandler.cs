using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial
{
    public class SearchLeyReferencialQueryHandler : SearchQueryHandlerBase<SearchLeyReferencialQuery, SearchLeyReferencialFilterDto, SearchLeyReferencialDto>
    {
        private readonly IRepository<Entities.LeyReferencial> _leyreferencialRepository;

        public SearchLeyReferencialQueryHandler(
            IMapper mapper,
            IRepository<Entities.LeyReferencial> leyreferencialRepository
        ) : base(mapper)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> HandleQuery(SearchLeyReferencialQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLeyReferencialDto>>();

            Expression<Func<Entities.LeyReferencial, bool>> filter = x => true;

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

            if (!string.IsNullOrEmpty(filters?.Dueno))
                filter = filter.And(x => x.IdDuenoMuestraNavigation.Nombres.Contains(filters.Dueno));

            var leyreferencials = await _leyreferencialRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdDuenoMuestraNavigation,
                x => x.IdTipoMineralNavigation!
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
