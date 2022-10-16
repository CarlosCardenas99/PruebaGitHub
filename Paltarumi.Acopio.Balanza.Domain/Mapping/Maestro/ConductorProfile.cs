using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ConductorProfile : Profile
    {
        public ConductorProfile()
        {
            CreateMap<Entity.Conductor, ConductorDto>()
                .ReverseMap();

            CreateMap<Entity.Conductor, GetConductorDto>()
                .ForMember(x => x.TipoLicencia, opt => opt.MapFrom(x => x.IdTipoLicenciaNavigation != null ? x.IdTipoLicenciaNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
