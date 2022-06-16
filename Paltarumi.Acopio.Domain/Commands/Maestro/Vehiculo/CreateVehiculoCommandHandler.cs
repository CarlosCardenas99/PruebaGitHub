using AutoMapper;
using Paltarumi.Acopio.Common;
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

        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public CreateVehiculoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateVehiculoCommandValidator validator,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        public override async Task<ResponseDto<GetVehiculoDto>> HandleCommand(CreateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = _mapper?.Map<Entity.Vehiculo>(request.CreateDto);

            if (vehiculo != null)
            {
                vehiculo.Activo = true;

                if (!request.CreateDto.IdTipoVehiculo.HasValue || request.CreateDto.IdTipoVehiculo == 0)
                {
                    vehiculo.IdTipoVehiculoNavigation = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_TIPO, request.CreateDto.DescripcionTipoVehiculo);
                    vehiculo.IdTipoVehiculo = vehiculo.IdTipoVehiculoNavigation.IdMaestro;
                }

                if (!request.CreateDto.IdVehiculoMarca.HasValue || request.CreateDto.IdVehiculoMarca == 0)
                {
                    vehiculo.IdVehiculoMarcaNavigation = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_MARCA, request.CreateDto.DescripcionVehiculoMarca);
                    vehiculo.IdTipoVehiculo = vehiculo.IdVehiculoMarcaNavigation.IdMaestro;
                }

                await _vehiculoRepository.AddAsync(vehiculo);
                await _vehiculoRepository.SaveAsync();
            }

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);
            if (vehiculoDto != null) response.UpdateData(vehiculoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }

        private async Task<Entity.Maestro> GetMaestro(string codigoTabla, string? descripcion)
        {
            var tipoVehiculos = await _maestroRepository.FindByAsNoTrackingAsync(
                x => x.CodigoTabla == codigoTabla
            );

            var codigoItem = tipoVehiculos.Max(x => x.CodigoItem);
            int.TryParse(codigoItem, out var codigoItemInt);

            codigoItem = $"0{codigoItemInt + 1}";
            codigoItem = codigoItem.Substring(codigoItem.Length - 2);

            return new Entity.Maestro
            {
                CodigoTabla = codigoTabla,
                CodigoItem = codigoItem,
                Descripcion = descripcion ?? string.Empty,
                Activo = true
            };
        }
    }
}
