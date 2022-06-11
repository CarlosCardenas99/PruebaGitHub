using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.CheckList
{
    public class SearchCheckListQueryHandler : SearchQueryHandlerBase<SearchCheckListQuery, SearchCheckListFilterDto, SearchCheckListDto>
    {
        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public SearchCheckListQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.CheckList> checklistRepository
        ) : base(mapper)
        {
            _checklistRepository = checklistRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> HandleQuery(SearchCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchCheckListDto>>();

            Expression<Func<Entity.CheckList, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdCheckList.HasValue == true)
                filter = filter.And(x => x.IdCheckList == filters.IdCheckList.Value);

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
