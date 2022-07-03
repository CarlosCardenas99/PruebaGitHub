using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.ItemCheck
{
    public class ListItemCheckQueryHandler : QueryHandlerBase<ListItemCheckQuery, IEnumerable<ListItemCheckDto>>
    {
        private readonly IRepository<Entity.ItemCheck> _itemCheckRepository;

        public ListItemCheckQueryHandler(
            IMapper mapper,
            IRepository<Entity.ItemCheck> itemCheckRepository
        ) : base(mapper)
        {
            _itemCheckRepository = itemCheckRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListItemCheckDto>>> HandleQuery(ListItemCheckQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListItemCheckDto>>();
            var list = await _itemCheckRepository.FindByAsync(x => x.Activo == true);
            var listDtos = _mapper?.Map<IEnumerable<ListItemCheckDto>>(list);

            response.UpdateData(listDtos ?? new List<ListItemCheckDto>());

            return await Task.FromResult(response);
        }
    }
}
