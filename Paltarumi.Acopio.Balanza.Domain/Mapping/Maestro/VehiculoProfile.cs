using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
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
