using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
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
