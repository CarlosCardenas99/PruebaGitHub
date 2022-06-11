using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class DeleteLoteCheckListCommandHandler : CommandHandlerBase<DeleteLoteCheckListCommand>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _lotechecklistRepository;

        public DeleteLoteCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLoteCheckListCommandValidator validator,
            IRepositoryBase<Entity.LoteCheckList> lotechecklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotechecklistRepository = lotechecklistRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lotechecklist = await _lotechecklistRepository.GetByAsync(x => x.IdLoteCheckList == request.Id);

            if (lotechecklist != null)
            {
                lotechecklist.Activo = false;
                await _lotechecklistRepository.UpdateAsync(lotechecklist);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
