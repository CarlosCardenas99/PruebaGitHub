using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.CheckList;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.CheckList
{
    public class SearchCheckListQueryHandler : SearchQueryHandlerBase<SearchCheckListQuery, SearchCheckListFilterDto, SearchCheckListDto>
    {
        private readonly IRepository<Entity.CheckList> _checklistRepository;

        public SearchCheckListQueryHandler(
            IMapper mapper,
            IRepository<Entity.CheckList> checklistRepository
        ) : base(mapper)
        {
            _checklistRepository = checklistRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> HandleQuery(SearchCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchCheckListDto>>();

            Expression<Func<Entity.CheckList, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdModulo.HasValue == true)
                filter = filter.And(x => x.IdModulo == filters.IdModulo);

            if (filters?.IdItemCheck.HasValue == true)
                filter = filter.And(x => x.IdItemCheck == filters.IdItemCheck);

            if (filters?.Mandatorio.HasValue == true)
                filter = filter.And(x => x.Mandatorio == filters.Mandatorio);

            var checklists = await _checklistRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var checklistDtos = _mapper?.Map<IEnumerable<SearchCheckListDto>>(checklists.Items);

            var searchResult = new SearchResultDto<SearchCheckListDto>(
                checklistDtos ?? new List<SearchCheckListDto>(),
                checklists.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
