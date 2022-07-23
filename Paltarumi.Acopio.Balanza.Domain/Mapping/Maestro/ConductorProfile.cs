using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ConductorProfile : Profile
    {
        public ConductorProfile()
        {
            CreateMap<Entity.Conductor, ConductorDto>()
                .ReverseMap();

            CreateMap<Entity.Conductor, CreateConductorDto>()
                .ReverseMap();

            CreateMap<Entity.Conductor, UpdateConductorDto>()
                .ReverseMap();

            CreateMap<Entity.Conductor, GetConductorDto>()
                .ForMember(x => x.TipoLicencia, opt => opt.MapFrom(x => x.IdTipoLicenciaNavigation != null ? x.IdTipoLicenciaNavigation.Descripcion : string.Empty))
                .ReverseMap();

            CreateMap<Entity.Conductor, SearchConductorDto>()
                .ForMember(x => x.TipoLicencia, opt => opt.MapFrom(x => x.IdTipoLicenciaNavigation != null ? x.IdTipoLicenciaNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
