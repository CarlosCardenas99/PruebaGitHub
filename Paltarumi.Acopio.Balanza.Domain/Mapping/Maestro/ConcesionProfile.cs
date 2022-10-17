using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Concesion;

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
