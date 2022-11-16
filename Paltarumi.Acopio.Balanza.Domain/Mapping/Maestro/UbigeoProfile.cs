using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<Ubigeo, UbigeoDto>()
                .ReverseMap();

            CreateMap<Ubigeo, GetUbigeoDto>()
                .ReverseMap();
        }
    }
}
