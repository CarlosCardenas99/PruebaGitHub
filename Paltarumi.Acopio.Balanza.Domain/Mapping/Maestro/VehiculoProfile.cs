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

            CreateMap<Entity.Vehiculo, GetVehiculoDto>()
                .ForMember(x => x.Marca, opt => opt.MapFrom(x => x.IdVehiculoMarcaNavigation))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdTipoVehiculoNavigation))
                .ReverseMap();
        }
    }
}
