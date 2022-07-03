using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.CheckList
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
