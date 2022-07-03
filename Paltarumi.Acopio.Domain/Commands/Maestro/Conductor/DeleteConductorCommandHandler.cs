using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class DeleteConductorCommandHandler : CommandHandlerBase<DeleteConductorCommand>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public DeleteConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteConductorCommandValidator validator,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteConductorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var conductor = await _conductorRepository.GetByAsync(x => x.IdConductor == request.Id);

            if (conductor != null)
            {
                conductor.Activo = false;
                await _conductorRepository.UpdateAsync(conductor);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
