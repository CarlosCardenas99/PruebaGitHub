using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.CheckList
{
    public class DeleteCheckListCommandHandler : CommandHandlerBase<DeleteCheckListCommand>
    {
        private readonly IRepository<Entity.CheckList> _checklistRepository;

        public DeleteCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteCheckListCommandValidator validator,
            IRepository<Entity.CheckList> checklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _checklistRepository = checklistRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var checklist = await _checklistRepository.GetByAsync(x => x.IdCheckList == request.Id);

            if (checklist != null)
            {
                checklist.Activo = false;
                await _checklistRepository.UpdateAsync(checklist);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
