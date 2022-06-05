using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandHandler : CommandHandlerBase<CreateVehiculoCommand, GetVehiculoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;

        public CreateVehiculoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateVehiculoCommandValidator validator,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public override async Task<ResponseDto<GetVehiculoDto>> HandleCommand(CreateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = _mapper?.Map<Entity.Vehiculo>(request.CreateDto);

            if (vehiculo != null)
            {
                vehiculo.Activo = true;


                await _vehiculoRepository.AddAsync(vehiculo);
                await _vehiculoRepository.SaveAsync();
            }

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);
            if (vehiculoDto != null) response.UpdateData(vehiculoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
