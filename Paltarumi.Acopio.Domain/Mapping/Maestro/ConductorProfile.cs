using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
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
                    .ReverseMap();
            CreateMap<Entity.Conductor, ListConductorDto>()
                    .ReverseMap();
        }
    }
}
