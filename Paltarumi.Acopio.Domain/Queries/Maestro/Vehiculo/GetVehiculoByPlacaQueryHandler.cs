using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQueryHandler : QueryHandlerBase<GetVehiculoByPlacaQuery, GetVehiculoDto>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public GetVehiculoByPlacaQueryHandler(
            IMapper mapper,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<GetVehiculoDto>> HandleQuery(GetVehiculoByPlacaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = await _vehiculoRepository.GetByAsync(
                x => x.Placa.Equals(request.Placa),
                x => x.IdTipoVehiculoNavigation,
                x => x.IdVehiculoMarcaNavigation
                );
            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);

            if (vehiculo != null && vehiculoDto != null)
            {
                vehiculoDto.TipoVehiculo = _mapper.Map<GetMaestroDto>(vehiculo.IdTipoVehiculoNavigation);
                vehiculoDto.Marca = _mapper.Map<GetMaestroDto>(vehiculo.IdVehiculoMarcaNavigation);
                response.UpdateData(vehiculoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
