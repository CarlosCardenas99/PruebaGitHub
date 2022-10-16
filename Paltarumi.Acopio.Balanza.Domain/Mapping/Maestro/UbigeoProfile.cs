using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<Entity.Ubigeo, UbigeoDto>()
                .ReverseMap();

            CreateMap<Entity.Ubigeo, GetUbigeoDto>()
                .ReverseMap();
        }
    }
}
