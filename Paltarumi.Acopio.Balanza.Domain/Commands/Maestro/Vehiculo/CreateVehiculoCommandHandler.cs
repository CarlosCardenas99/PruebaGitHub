using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandHandler : CommandHandlerBase<CreateVehiculoCommand, GetVehiculoDto>
    {
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

            request.CreateDto.Placa = request.CreateDto.Placa.ToUpper();
            request.CreateDto.PlacaCarreta = request.CreateDto.PlacaCarreta.ToUpper();

            if (request.CreateDto.Placa.Length == 6 )request.CreateDto.Placa = request.CreateDto.Placa.Insert(3, "-");

            if( request.CreateDto.PlacaCarreta.Length == 6) request.CreateDto.PlacaCarreta = request.CreateDto.PlacaCarreta.Insert(3, "-");
            
            var vehiculo = await _vehiculoRepository.GetByAsync(
                x => x.Placa == request.CreateDto.Placa &&
                x.Activo == true
            );

            var exists = vehiculo != null;

            if (exists)
                _mapper?.Map(request.CreateDto, vehiculo);
            else
                vehiculo = _mapper?.Map<Entity.Vehiculo>(request.CreateDto) ?? new Entity.Vehiculo();

            if (vehiculo != null)
            {
                if (request.CreateDto.IdTipoVehiculo == default)
                {
                    var maestro = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_TIPO, request.CreateDto.DescripcionTipoVehiculo);
                    vehiculo.IdTipoVehiculo = maestro.IdMaestro;
                    vehiculo.IdTipoVehiculoNavigation = (maestro.IdMaestro == default ? maestro : null)!;
                }

                if (request.CreateDto.IdVehiculoMarca == default)
                {
                    var maestro = await GetMaestro(Constants.Maestro.CodigoTabla.VEHICULO_MARCA, request.CreateDto.DescripcionTipoVehiculo);
                    vehiculo.IdVehiculoMarca = maestro.IdMaestro;
                    vehiculo.IdVehiculoMarcaNavigation = (maestro.IdMaestro == default ? maestro : null)!;
                }
            }

            if (exists)
                await _vehiculoRepository.UpdateAsync(vehiculo!);
            else
                await _vehiculoRepository.AddAsync(vehiculo!);

            await _vehiculoRepository.SaveAsync();

            vehiculo = await _vehiculoRepository.GetByAsNoTrackingAsync(
                x => x.IdVehiculo == vehiculo.IdVehiculo,
                x => x.IdTipoVehiculoNavigation,
                x => x.IdVehiculoMarcaNavigation
            );

            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);

            response.UpdateData(vehiculoDto!);
            response.AddOkResult(Resources.Common.CreateSuccessMessage);

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
