using AutoMapper;
using Paltarumi.Acopio.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<Entity.Ubigeo, UbigeoDto>()
                .ReverseMap();

            CreateMap<Entity.Ubigeo, CreateUbigeoDto>()
                .ReverseMap();

            CreateMap<Entity.Ubigeo, UpdateUbigeoDto>()
                .ReverseMap();

            CreateMap<Entity.Ubigeo, GetUbigeoDto>()
                .ReverseMap();

            CreateMap<Entity.Ubigeo, SearchUbigeoDto>()
                .ReverseMap();
        }
    }
}
