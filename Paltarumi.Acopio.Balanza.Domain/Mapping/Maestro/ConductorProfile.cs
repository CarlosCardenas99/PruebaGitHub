using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ConductorProfile : Profile
    {
        public ConductorProfile()
        {
            CreateMap<Conductor, ConductorDto>()
                .ReverseMap();

            CreateMap<Conductor, GetConductorDto>()
                .ForMember(x => x.TipoLicencia, opt => opt.MapFrom(x => x.IdTipoLicenciaNavigation != null ? x.IdTipoLicenciaNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
