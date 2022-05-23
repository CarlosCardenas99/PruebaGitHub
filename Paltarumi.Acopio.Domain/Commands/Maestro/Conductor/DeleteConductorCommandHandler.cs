using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class DeleteConductorCommandHandler : CommandHandlerBase<DeleteConductorCommand>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public DeleteConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteConductorCommandValidator validator,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteConductorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            var conductor = await _conductorRepository.GetByAsync(x => x.IdConductor == request.Id);
            if (conductor != null) await _conductorRepository.DeleteAsync(conductor);

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
