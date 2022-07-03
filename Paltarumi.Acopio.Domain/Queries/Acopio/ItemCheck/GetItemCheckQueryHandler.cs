using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.ItemCheck
{
    public class GetItemCheckQueryHandler : QueryHandlerBase<GetItemCheckQuery, GetItemCheckDto>
    {
        private readonly IRepository<Entity.ItemCheck> _itemcheckRepository;

        public GetItemCheckQueryHandler(
            IMapper mapper,
            GetItemCheckQueryValidator validator,
            IRepository<Entity.ItemCheck> itemcheckRepository
        ) : base(mapper, validator)
        {
            _itemcheckRepository = itemcheckRepository;
        }

        protected override async Task<ResponseDto<GetItemCheckDto>> HandleQuery(GetItemCheckQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetItemCheckDto>();
            var itemcheck = await _itemcheckRepository.GetByAsync(x => x.IdItemCheck == request.Id);
            var itemcheckDto = _mapper?.Map<GetItemCheckDto>(itemcheck);

            if (itemcheck != null && itemcheckDto != null)
            {
                response.UpdateData(itemcheckDto);
            }

            return await Task.FromResult(response);
        }
    }
}
