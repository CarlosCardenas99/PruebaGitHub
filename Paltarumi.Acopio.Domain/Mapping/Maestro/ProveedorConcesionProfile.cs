using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class ProveedorConcesionProfile : Profile
    {
        public ProveedorConcesionProfile()
        {
            CreateMap<Entity.ProveedorConcesion, ProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, CreateProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, UpdateProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, GetProveedorConcesionDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.CodigoUnico + " - " + x.IdConcesionNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, SearchProveedorConcesionDto>()
                .ReverseMap();
        }
    }
}
