using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ConcesionProfile : Profile
    {
        public ConcesionProfile()
        {
            CreateMap<Concesion, ConcesionDto>()
                .ReverseMap();

            CreateMap<Concesion, GetConcesionDto>()
                .ReverseMap();
        }
    }
}
