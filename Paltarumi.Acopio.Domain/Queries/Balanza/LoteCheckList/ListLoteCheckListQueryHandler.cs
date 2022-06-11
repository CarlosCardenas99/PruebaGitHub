using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList
{
    public class ListLoteCheckListQueryHandler : QueryHandlerBase<ListLoteCheckListQuery, IEnumerable<ListLoteCheckListDto>>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _repository;

        public ListLoteCheckListQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LoteCheckList> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> HandleQuery(ListLoteCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteCheckListDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListLoteCheckListDto>>(list);

            response.UpdateData(listDtos ?? new List<ListLoteCheckListDto>());

            return await Task.FromResult(response);
        }
    }
}
