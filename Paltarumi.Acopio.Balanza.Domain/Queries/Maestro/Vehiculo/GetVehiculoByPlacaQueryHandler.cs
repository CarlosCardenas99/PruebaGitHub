using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQueryHandler : QueryHandlerBase<GetVehiculoByPlacaQuery, GetVehiculoDto>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public GetVehiculoByPlacaQueryHandler(
            IMapper mapper,
            GetVehiculoByPlacaQueryValidator validator,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper, validator)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<GetVehiculoDto>> HandleQuery(GetVehiculoByPlacaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();

            request.Placa = request.Placa.Replace(" ", string.Empty);
            request.Placa=request.Placa.ToUpper();

            if (request.Placa.Length ==6) request.Placa = request.Placa.Insert(3, "-");

            var vehiculo = await _vehiculoRepository.GetByAsync(
                x => x.Placa.Equals(request.Placa),
                x => x.IdTipoVehiculoNavigation,
                x => x.IdVehiculoMarcaNavigation
                );
            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);

            if (vehiculo != null && vehiculoDto != null && _mapper != null)
            {
                vehiculoDto.TipoVehiculo = _mapper.Map<GetMaestroDto>(vehiculo.IdTipoVehiculoNavigation);
                vehiculoDto.Marca = _mapper.Map<GetMaestroDto>(vehiculo.IdVehiculoMarcaNavigation);
                response.UpdateData(vehiculoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
