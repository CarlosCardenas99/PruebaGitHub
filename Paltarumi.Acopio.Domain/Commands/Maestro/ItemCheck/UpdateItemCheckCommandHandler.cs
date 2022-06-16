using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
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
