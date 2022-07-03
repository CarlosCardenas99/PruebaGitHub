using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
{
    public class DeleteItemCheckCommandHandler : CommandHandlerBase<DeleteItemCheckCommand>
    {
        private readonly IRepository<Entity.ItemCheck> _itemcheckRepository;

        public DeleteItemCheckCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteItemCheckCommandValidator validator,
            IRepository<Entity.ItemCheck> itemcheckRepository
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
