using AutoMapper;
using Paltarumi.Acopio.Dto.Config.Modulo;

namespace Paltarumi.Acopio.Domain.Mapping.Config
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
