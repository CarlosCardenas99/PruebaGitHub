using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class SearchItemCheckQueryHandler : SearchQueryHandlerBase<SearchItemCheckQuery, SearchItemCheckFilterDto, SearchItemCheckDto>
    {
        private readonly IRepositoryBase<Entity.ItemCheck> _itemcheckRepository;

        public SearchItemCheckQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.ItemCheck> itemcheckRepository
        ) : base(mapper)
        {
            _itemcheckRepository = itemcheckRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchItemCheckDto>>> HandleQuery(SearchItemCheckQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchItemCheckDto>>();

            Expression<Func<Entity.ItemCheck, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdItemCheck.HasValue == true)
                filter = filter.And(x => x.IdItemCheck == filters.IdItemCheck.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var itemchecks = await _itemcheckRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var itemcheckDtos = _mapper?.Map<IEnumerable<SearchItemCheckDto>>(itemchecks.Items);

            var searchResult = new SearchResultDto<SearchItemCheckDto>(
                itemcheckDtos ?? new List<SearchItemCheckDto>(),
                itemchecks.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
