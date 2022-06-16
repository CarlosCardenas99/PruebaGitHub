using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class DeleteConcesionCommandHandler : CommandHandlerBase<DeleteConcesionCommand>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public DeleteConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteConcesionCommandValidator validator,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _concesionRepository = concesionRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var concesion = await _concesionRepository.GetByAsync(x => x.IdConcesion == request.Id);

            if (concesion != null)
            {
                concesion.Activo = false;
                await _concesionRepository.UpdateAsync(concesion);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
