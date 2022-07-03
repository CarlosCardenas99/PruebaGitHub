using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
{
    public class UpdateItemCheckCommandHandler : CommandHandlerBase<UpdateItemCheckCommand, GetItemCheckDto>
    {
        private readonly IRepository<Entity.ItemCheck> _itemcheckRepository;

        public UpdateItemCheckCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateItemCheckCommandValidator validator,
            IRepository<Entity.ItemCheck> itemcheckRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _itemcheckRepository = itemcheckRepository;
        }

        public override async Task<ResponseDto<GetItemCheckDto>> HandleCommand(UpdateItemCheckCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetItemCheckDto>();
            var itemcheck = await _itemcheckRepository.GetByAsync(x => x.IdItemCheck == request.UpdateDto.IdItemCheck);

            if (itemcheck != null)
            {
                _mapper?.Map(request.UpdateDto, itemcheck);
                await _itemcheckRepository.UpdateAsync(itemcheck);
            }

            var itemcheckDto = _mapper?.Map<GetItemCheckDto>(itemcheck);
            if (itemcheckDto != null) response.UpdateData(itemcheckDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
