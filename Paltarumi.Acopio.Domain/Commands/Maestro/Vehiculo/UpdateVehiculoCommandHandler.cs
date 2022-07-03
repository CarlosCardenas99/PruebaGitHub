using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommandHandler : CommandHandlerBase<UpdateVehiculoCommand, GetVehiculoDto>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public UpdateVehiculoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateVehiculoCommandValidator validator,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        public override async Task<ResponseDto<GetVehiculoDto>> HandleCommand(UpdateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = await _vehiculoRepository.GetByAsync(x => x.IdVehiculo == request.UpdateDto.IdVehiculo);

            if (vehiculo != null)
            {
                _mapper?.Map(request.UpdateDto, vehiculo);

                if (!request.UpdateDto.IdTipoVehiculo.HasValue || request.UpdateDto.IdTipoVehiculo == 0)
                {
                    vehiculo.IdTipoVehiculoNavigation = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_TIPO, request.UpdateDto.DescripcionTipoVehiculo);
                    vehiculo.IdTipoVehiculo = vehiculo.IdTipoVehiculoNavigation.IdMaestro;
                }

                if (!request.UpdateDto.IdVehiculoMarca.HasValue || request.UpdateDto.IdVehiculoMarca == 0)
                {
                    vehiculo.IdVehiculoMarcaNavigation = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_MARCA, request.UpdateDto.DescripcionVehiculoMarca);
                    vehiculo.IdTipoVehiculo = vehiculo.IdVehiculoMarcaNavigation.IdMaestro;
                }

                await _vehiculoRepository.UpdateAsync(vehiculo);
            }

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);
            if (vehiculoDto != null) response.UpdateData(vehiculoDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

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
