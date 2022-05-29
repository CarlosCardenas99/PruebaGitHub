using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class MaestroProfile : Profile
    {
        public MaestroProfile()
        {
            CreateMap<Entity.Maestro, MaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, CreateMaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, UpdateMaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, GetMaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, SearchMaestroDto>()
                .ReverseMap();
        }
    }
}
