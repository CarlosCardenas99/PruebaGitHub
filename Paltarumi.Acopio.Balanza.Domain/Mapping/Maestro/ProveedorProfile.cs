using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Paltarumi.Acopio.Entity.Proveedor, ProveedorDto>()
                .ReverseMap();

            CreateMap<Paltarumi.Acopio.Entity.Proveedor, GetProveedorDto>()
                .ReverseMap();

        }
    }
}
