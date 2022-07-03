using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.ItemCheck
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
