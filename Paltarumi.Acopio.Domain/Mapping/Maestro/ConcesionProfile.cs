using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class ConcesionProfile : Profile
    {
        public ConcesionProfile()
        {
            CreateMap<Entity.Concesion, ConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, CreateConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, UpdateConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, GetConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, SelectConcesionDto>()
                .ReverseMap();
            
            CreateMap<Entity.Concesion, SearchConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, ListConcesionDto>()
                .ReverseMap();
        }
    }
}
