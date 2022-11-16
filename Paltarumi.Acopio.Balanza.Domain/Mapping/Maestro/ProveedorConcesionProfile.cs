using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ProveedorConcesionProfile : Profile
    {
        public ProveedorConcesionProfile()
        {
            CreateMap<ProveedorConcesion, ProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<ProveedorConcesion, GetProveedorConcesionDto>()
                .ReverseMap();

            CreateMap<ProveedorConcesion, ListProveedorConcesionDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.CodigoUnico + " - " + x.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.CodigoUbigeo, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.CodigoUbigeo : string.Empty))
                .ReverseMap();
        }
    }
}
