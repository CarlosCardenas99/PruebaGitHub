using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.ItemCheck
{
    public class CreateItemCheckCommandHandler : CommandHandlerBase<CreateItemCheckCommand, GetItemCheckDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.ItemCheck> _itemcheckRepository;

        public CreateItemCheckCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateItemCheckCommandValidator validator,
            IRepository<Entity.ItemCheck> itemcheckRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _itemcheckRepository = itemcheckRepository;
        }

        public override async Task<ResponseDto<GetItemCheckDto>> HandleCommand(CreateItemCheckCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetItemCheckDto>();
            var itemcheck = _mapper?.Map<Entity.ItemCheck>(request.CreateDto);

            if (itemcheck != null)
            {
                itemcheck.Activo = true;


                await _itemcheckRepository.AddAsync(itemcheck);
                await _itemcheckRepository.SaveAsync();
            }

            var itemcheckDto = _mapper?.Map<GetItemCheckDto>(itemcheck);
            if (itemcheckDto != null) response.UpdateData(itemcheckDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
