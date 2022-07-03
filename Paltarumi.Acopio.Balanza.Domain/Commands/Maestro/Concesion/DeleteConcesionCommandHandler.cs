using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
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
