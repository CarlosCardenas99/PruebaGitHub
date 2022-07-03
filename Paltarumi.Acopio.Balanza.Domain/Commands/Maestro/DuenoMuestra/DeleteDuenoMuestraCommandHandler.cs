using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class DeleteDuenoMuestraCommandHandler : CommandHandlerBase<DeleteDuenoMuestraCommand>
    {
        private readonly IRepository<Entity.DuenoMuestra> _duenomuestraRepository;

        public DeleteDuenoMuestraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteDuenoMuestraCommandValidator validator,
            IRepository<Entity.DuenoMuestra> duenomuestraRepository
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
