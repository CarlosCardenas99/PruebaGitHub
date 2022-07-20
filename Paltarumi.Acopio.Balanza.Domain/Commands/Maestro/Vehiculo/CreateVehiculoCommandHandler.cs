using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandHandler : CommandHandlerBase<CreateVehiculoCommand, GetVehiculoDto>
    {
        //protected override bool UseTransaction => false;

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
            Entity.Vehiculo? vehiculo;

            var updateDto = await _vehiculoRepository.GetByAsync(
                   x => x.Placa == request.CreateDto.Placa && x.Activo == true
                   );

            if (updateDto != null)
            {
                _mapper?.Map(request.CreateDto, updateDto);

                vehiculo = new Entity.Vehiculo();
                _mapper?.Map(updateDto, vehiculo);
            }
            else
            {
                vehiculo = _mapper?.Map<Entity.Vehiculo>(request.CreateDto);
            }

            if (vehiculo != null)
            {
                vehiculo.Activo = true;

                if (request.CreateDto.IdTipoVehiculo == default)
                {
                    int IdTipoVehiculo = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_TIPO, request.CreateDto.DescripcionTipoVehiculo);
                    vehiculo.IdTipoVehiculo = IdTipoVehiculo;
                }

                if (request.CreateDto.IdVehiculoMarca == default)
                {
                    int IdMarcaVehiculo = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_MARCA, request.CreateDto.DescripcionTipoVehiculo);
                    vehiculo.IdVehiculoMarca = IdMarcaVehiculo;
                }

                if (vehiculo.IdVehiculo > 0)
                {
                    await _vehiculoRepository.UpdateAsync(vehiculo);
                }
                else
                {
                    await _vehiculoRepository.AddAsync(vehiculo);
                    await _vehiculoRepository.SaveAsync();
                }

                var consultaVehiculo = await _vehiculoRepository.GetByAsync(
                   x => x.IdVehiculo == vehiculo.IdVehiculo,
                   x => x.IdTipoVehiculoNavigation,
                   x => x.IdVehiculoMarcaNavigation
                   );

                var vehiculoDto = _mapper?.Map<GetVehiculoDto>(consultaVehiculo);

                if (consultaVehiculo != null && vehiculoDto != null && _mapper != null)
                {
                    vehiculoDto.Marca = consultaVehiculo.IdVehiculoMarcaNavigation == null ? null : _mapper.Map<GetMaestroDto>(consultaVehiculo.IdVehiculoMarcaNavigation);
                    vehiculoDto.TipoVehiculo = consultaVehiculo.IdTipoVehiculoNavigation == null ? null : _mapper.Map<GetMaestroDto>(consultaVehiculo.IdTipoVehiculoNavigation);

                    response.UpdateData(vehiculoDto);
                }
            }

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }

        private async Task<int> GetMaestro(string codigoTabla, string? descripcion)
        {
            var tipoVehiculos = await _maestroRepository.FindByAsNoTrackingAsync(
                x => x.CodigoTabla == codigoTabla
            );

            var codigoItem = tipoVehiculos.Max(x => x.CodigoItem);
            int.TryParse(codigoItem, out var codigoItemInt);

            codigoItem = $"0{codigoItemInt + 1}";
            codigoItem = codigoItem.Substring(codigoItem.Length - 2);

            var maestro = new Entity.Maestro
            {
                CodigoTabla = codigoTabla,
                CodigoItem = codigoItem,
                Descripcion = descripcion ?? string.Empty,
                Activo = true
            };

            await _maestroRepository.AddAsync(maestro);
            await _maestroRepository.SaveAsync();

            return maestro.IdMaestro;
        }
    }
}
