using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Entity.Proveedor, ProveedorDto>()
                .ReverseMap();

            CreateMap<Entity.Proveedor, CreateProveedorDto>()
                .ReverseMap();

            CreateMap<Entity.Proveedor, UpdateProveedorDto>()
                .ReverseMap();

            CreateMap<Entity.Proveedor, GetProveedorDto>()
                .ReverseMap();

            CreateMap<Entity.Proveedor, SearchProveedorDto>()
                .ReverseMap();
        }
    }
}
