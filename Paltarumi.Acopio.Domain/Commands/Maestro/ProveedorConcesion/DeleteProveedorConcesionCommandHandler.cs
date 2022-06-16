using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class DeleteProveedorConcesionCommandHandler : CommandHandlerBase<DeleteProveedorConcesionCommand>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public DeleteProveedorConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteProveedorConcesionCommandValidator validator,
            IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteProveedorConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var proveedorconcesion = await _proveedorconcesionRepository.GetByAsync(x => x.IdProveedorConcesion == request.Id);

            if (proveedorconcesion != null)
            {
                proveedorconcesion.Activo = false;
                await _proveedorconcesionRepository.UpdateAsync(proveedorconcesion);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
