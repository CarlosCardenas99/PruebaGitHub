using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
{
    public class DeleteItemCheckCommandHandler : CommandHandlerBase<DeleteItemCheckCommand>
    {
        private readonly IRepositoryBase<Entity.ItemCheck> _itemcheckRepository;

        public DeleteItemCheckCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteItemCheckCommandValidator validator,
            IRepositoryBase<Entity.ItemCheck> itemcheckRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _itemcheckRepository = itemcheckRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteItemCheckCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var itemcheck = await _itemcheckRepository.GetByAsync(x => x.IdItemCheck == request.Id);

            if (itemcheck != null)
            {
                itemcheck.Activo = false;
                await _itemcheckRepository.UpdateAsync(itemcheck);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
