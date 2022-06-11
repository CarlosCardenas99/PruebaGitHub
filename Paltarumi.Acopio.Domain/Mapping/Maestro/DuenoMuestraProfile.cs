using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class DuenoMuestraProfile : Profile
    {
        public DuenoMuestraProfile()
        {
            CreateMap<Entity.DuenoMuestra, DuenoMuestraDto>()
                .ReverseMap();

            CreateMap<Entity.DuenoMuestra, CreateDuenoMuestraDto>()
                .ReverseMap();

            CreateMap<Entity.DuenoMuestra, UpdateDuenoMuestraDto>()
                .ReverseMap();

            CreateMap<Entity.DuenoMuestra, GetDuenoMuestraDto>()
                .ReverseMap();

            CreateMap<Entity.DuenoMuestra, SearchDuenoMuestraDto>()
                .ReverseMap();
        }
    }
}
