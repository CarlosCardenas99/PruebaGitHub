using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Chancado
{
    public class MapaProfile : Profile
    {
        public MapaProfile()
        {
            CreateMap<Mapa, MapaDto>()
                .ReverseMap();

            CreateMap<Mapa, CreateMapaDto>()
                .ReverseMap();

            CreateMap<Mapa, GetMapaDto>()
                .ReverseMap();

            CreateMap<Mapa, UpdateMapaDto>()
               .ReverseMap();

            CreateMap<Mapa, UpdateMapaEstadoDto>()
               .ReverseMap();
        }
    }
}
