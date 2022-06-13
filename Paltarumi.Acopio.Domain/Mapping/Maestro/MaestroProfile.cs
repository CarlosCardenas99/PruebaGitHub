using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
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
                //.ForMember(x => x.Descripcion, opt => opt.MapFrom(x => x.Tickets != null ? string.Join(",", x.Tickets.Select(x => x.Numero)) : string.Empty))
                .ReverseMap();
        }
    }
}
