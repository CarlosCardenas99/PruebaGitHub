using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Vehiculo, VehiculoDto>()
                .ReverseMap();

            CreateMap<Vehiculo, GetVehiculoDto>()
                .ForMember(x => x.Marca, opt => opt.MapFrom(x => x.IdVehiculoMarcaNavigation))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdTipoVehiculoNavigation))
                .ReverseMap();
        }
    }
}
