using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ProveedorConcesionProfile : Profile
    {
        public ProveedorConcesionProfile()
        {
            CreateMap<Entity.ProveedorConcesion, ProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.ProveedorConcesion, GetProveedorConcesionDto>()
                .ReverseMap();


            CreateMap<Entity.ProveedorConcesion, ListProveedorConcesionDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.CodigoUnico + " - " + x.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.CodigoUbigeo, opt => opt.MapFrom(x => x.IdConcesionNavigation!= null ? x.IdConcesionNavigation.CodigoUbigeo : string.Empty))
                .ReverseMap();

        }
    }
}
