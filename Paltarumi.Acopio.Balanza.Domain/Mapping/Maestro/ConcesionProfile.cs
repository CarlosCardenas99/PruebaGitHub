using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ConcesionProfile : Profile
    {
        public ConcesionProfile()
        {
            CreateMap<Entity.Concesion, ConcesionDto>()
                .ReverseMap();

            CreateMap<Entity.Concesion, GetConcesionDto>()
                .ReverseMap();
        }
    }
}
