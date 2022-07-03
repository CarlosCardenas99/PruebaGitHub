using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Acopio.CheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.CheckList
{
    public class ListCheckListQueryHandler : QueryHandlerBase<ListCheckListQuery, IEnumerable<ListCheckListDto>>
    {
        private readonly IRepository<Entity.CheckList> _repository;

        public ListCheckListQueryHandler(
            IMapper mapper,
            IRepository<Entity.CheckList> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListCheckListDto>>> HandleQuery(ListCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListCheckListDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListCheckListDto>>(list);

            response.UpdateData(listDtos ?? new List<ListCheckListDto>());

            return await Task.FromResult(response);
        }
    }
}
