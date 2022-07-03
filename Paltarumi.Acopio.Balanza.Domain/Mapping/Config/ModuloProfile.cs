using AutoMapper;
using Paltarumi.Acopio.Config.Dto.Modulo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Config
{
    public class ModuloProfile : Profile
    {
        public ModuloProfile()
        {
            CreateMap<Entity.Modulo, ModuloDto>()
                .ReverseMap();

            CreateMap<Entity.Modulo, GetModuloDto>()
                .ReverseMap();

            CreateMap<Entity.Modulo, SearchModuloDto>()
                .ReverseMap();

            CreateMap<Entity.Modulo, ListModuloDto>()
                .ReverseMap();
        }
    }
}
