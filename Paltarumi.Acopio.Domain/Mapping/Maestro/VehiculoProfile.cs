using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Entity.Vehiculo, VehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, CreateVehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, UpdateVehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, GetVehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, SearchVehiculoDto>()
                .ReverseMap();
        }
    }
}
