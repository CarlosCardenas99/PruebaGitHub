using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Entity.Proveedor, ProveedorDto>()
                .ReverseMap();


            CreateMap<Entity.Proveedor, GetProveedorDto>()
                .ReverseMap();

        }
    }
}
