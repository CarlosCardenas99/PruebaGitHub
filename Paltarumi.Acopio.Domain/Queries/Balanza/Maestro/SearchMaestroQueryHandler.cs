using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;
using Paltarumi.Acopio.Entity.Base;

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

            List<SortExpression<Entity.Maestro>> listSortExpression = new List<SortExpression<Entity.Maestro>>();
            /*
            Expression<Func<Entity.Maestro, object>> sortFuntion = x => x.CodigoItem;
            SortExpression<Entity.Maestro> sortExpression = new SortExpression<Entity.Maestro>();
            sortExpression.Property = sortFuntion;
            sortExpression.Direction = SortDirection.Desc;
            listSortExpression.Add(sortExpression);
            */

            var filters = request.SearchParams?.Filter;

            filter = filter.And(x => x.Activo == true);

            if (!String.IsNullOrEmpty(filters?.CodigoTabla))
                filter = filter.And(x => x.CodigoTabla == filters.CodigoTabla);

            var maestros = await _maestroRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                listSortExpression,
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
