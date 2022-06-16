using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoQueryHandler : QueryHandlerBase<GetVehiculoQuery, GetVehiculoDto>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public GetVehiculoQueryHandler(
            IMapper mapper,
            GetVehiculoQueryValidator validator,
            IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper, validator)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        protected override async Task<ResponseDto<GetVehiculoDto>> HandleQuery(GetVehiculoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetVehiculoDto>();
            var vehiculo = await _vehiculoRepository.GetByAsync(x => x.IdVehiculo == request.Id);
            var vehiculoDto = _mapper?.Map<GetVehiculoDto>(vehiculo);

            if (vehiculo != null && vehiculoDto != null)
            {
                response.UpdateData(vehiculoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
