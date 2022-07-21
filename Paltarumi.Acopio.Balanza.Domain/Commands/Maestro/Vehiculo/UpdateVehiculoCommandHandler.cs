using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
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

            //________________________
            request.UpdateDto.Placa = request.UpdateDto.Placa.ToUpper();
            request.UpdateDto.PlacaCarreta = request.UpdateDto.PlacaCarreta.ToUpper();

            if (request.UpdateDto.Placa.Length == 6) request.UpdateDto.Placa = request.UpdateDto.Placa.Insert(3, "-");

            if (request.UpdateDto.PlacaCarreta.Length == 6) request.UpdateDto.PlacaCarreta = request.UpdateDto.PlacaCarreta.Insert(3, "-");
            //________________________

            var vehiculo = await _vehiculoRepository.GetByAsync(x => x.IdVehiculo == request.UpdateDto.IdVehiculo);

            if (vehiculo != null)
            {
                _mapper?.Map(request.UpdateDto, vehiculo);

                if (request.UpdateDto.IdTipoVehiculo == default)
                {
                    var maestro = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_TIPO, request.UpdateDto.DescripcionTipoVehiculo);
                    vehiculo.IdTipoVehiculo = maestro.IdMaestro;
                    vehiculo.IdTipoVehiculoNavigation = (maestro.IdMaestro == default ? maestro : null)!;
                }

                if (request.UpdateDto.IdVehiculoMarca == default)
                {
                    var maestro = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_MARCA, request.UpdateDto.DescripcionTipoVehiculo);
                    vehiculo.IdVehiculoMarca = maestro.IdMaestro;
                    vehiculo.IdVehiculoMarcaNavigation = (maestro.IdMaestro == default ? maestro : null)!;
                }

                await _vehiculoRepository.UpdateAsync(vehiculo);
            }
            vehiculo = await _vehiculoRepository.GetByAsNoTrackingAsync(
               x => x.IdVehiculo == vehiculo.IdVehiculo,
               x => x.IdTipoVehiculoNavigation,
               x => x.IdVehiculoMarcaNavigation
           );

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);
            if (vehiculoDto != null) response.UpdateData(vehiculoDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }

        private async Task<Entity.Maestro> GetMaestro(string codigoTabla, string? descripcion)
        {
            var maestro = await _maestroRepository.GetByAsNoTrackingAsync(
                x => x.CodigoTabla == codigoTabla && x.Descripcion == descripcion
            );

            if (maestro != null) return maestro;

            var maestros = await _maestroRepository.FindByAsNoTrackingAsync(
                x => x.CodigoTabla == codigoTabla
            );

            var codigoItem = maestros.Max(x => x.CodigoItem);
            int.TryParse(codigoItem, out var codigoItemInt);

            codigoItem = $"0{codigoItemInt + 1}";
            codigoItem = codigoItem.Substring(codigoItem.Length - 2);

            maestro = new Entity.Maestro
            {
                CodigoTabla = codigoTabla,
                CodigoItem = codigoItem,
                Descripcion = descripcion ?? string.Empty,
                Activo = true
            };

            await _maestroRepository.AddAsync(maestro);

            return maestro;
        }
    }
}
