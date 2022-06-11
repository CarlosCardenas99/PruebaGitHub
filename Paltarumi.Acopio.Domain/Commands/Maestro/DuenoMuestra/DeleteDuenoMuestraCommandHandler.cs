using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class DeleteDuenoMuestraCommandHandler : CommandHandlerBase<DeleteDuenoMuestraCommand>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenomuestraRepository;

        public DeleteDuenoMuestraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteDuenoMuestraCommandValidator validator,
            IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _duenomuestraRepository = duenomuestraRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteDuenoMuestraCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var duenomuestra = await _duenomuestraRepository.GetByAsync(x => x.IdDuenoMuestra == request.Id);

            if (duenomuestra != null)
            {
                duenomuestra.Activo = false;
                await _duenomuestraRepository.UpdateAsync(duenomuestra);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
