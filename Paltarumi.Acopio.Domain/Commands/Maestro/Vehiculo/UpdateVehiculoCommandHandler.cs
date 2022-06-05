using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommandHandler : CommandHandlerBase<UpdateVehiculoCommand, GetVehiculoDto>
    {
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;

        public UpdateVehiculoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateVehiculoCommandValidator validator,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public override async Task<ResponseDto<GetVehiculoDto>> HandleCommand(UpdateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = await _vehiculoRepository.GetByAsync(x => x.IdVehiculo == request.UpdateDto.IdVehiculo);

            if (vehiculo != null)
            {
                _mapper?.Map(request.UpdateDto, vehiculo);
                await _vehiculoRepository.UpdateAsync(vehiculo);
            }

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);
            if (vehiculoDto != null) response.UpdateData(vehiculoDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
