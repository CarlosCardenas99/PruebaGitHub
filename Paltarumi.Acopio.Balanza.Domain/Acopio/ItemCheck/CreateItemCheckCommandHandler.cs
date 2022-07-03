using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
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
