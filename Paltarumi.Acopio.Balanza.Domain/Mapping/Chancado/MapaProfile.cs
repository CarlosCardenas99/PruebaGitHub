using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Chancado
{
    public class MapaProfile : Profile
    {
        public MapaProfile()
        {
            CreateMap<Entity.Mapa, MapaDto>()
                .ReverseMap();

            CreateMap<Entity.Mapa, CreateMapaDto>()
                .ReverseMap();

            CreateMap<Entity.Mapa, GetMapaDto>()
                .ReverseMap();
        }
    }
}
