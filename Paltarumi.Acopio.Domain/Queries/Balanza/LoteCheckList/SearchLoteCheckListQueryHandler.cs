using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList
{
    public class SearchLoteCheckListQueryHandler : SearchQueryHandlerBase<SearchLoteCheckListQuery, SearchLoteCheckListFilterDto, SearchLoteCheckListDto>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _lotechecklistRepository;

        public SearchLoteCheckListQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LoteCheckList> lotechecklistRepository
        ) : base(mapper)
        {
            _lotechecklistRepository = lotechecklistRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteCheckListDto>>> HandleQuery(SearchLoteCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteCheckListDto>>();

            Expression<Func<Entity.LoteCheckList, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdLoteCheckList.HasValue == true)
                filter = filter.And(x => x.IdLoteCheckList == filters.IdLoteCheckList.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var lotechecklists = await _lotechecklistRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var lotechecklistDtos = _mapper?.Map<IEnumerable<SearchLoteCheckListDto>>(lotechecklists.Items);

            var searchResult = new SearchResultDto<SearchLoteCheckListDto>(
                lotechecklistDtos ?? new List<SearchLoteCheckListDto>(),
                lotechecklists.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
