using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ProveedorConcesionProfile : Profile
    {
        public ProveedorConcesionProfile()
        {
            CreateMap<Entity.ProveedorConcesion, ProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, CreateProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, GetProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, UpdateProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, ListProveedorConcesionDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.CodigoUnico + " - " + x.IdConcesionNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, SearchProveedorConcesionDto>()
                .ReverseMap();
        }
    }
}
