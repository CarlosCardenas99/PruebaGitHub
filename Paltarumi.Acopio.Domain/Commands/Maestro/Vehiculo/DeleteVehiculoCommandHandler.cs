using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class DeleteVehiculoCommandHandler : CommandHandlerBase<DeleteVehiculoCommand>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public DeleteVehiculoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteVehiculoCommandValidator validator,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteVehiculoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var vehiculo = await _vehiculoRepository.GetByAsync(x => x.IdVehiculo == request.Id);

            if (vehiculo != null)
            {
                vehiculo.Activo = false;
                await _vehiculoRepository.UpdateAsync(vehiculo);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
