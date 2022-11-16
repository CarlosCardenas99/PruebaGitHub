using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class DuenoMuestraProfile : Profile
    {
        public DuenoMuestraProfile()
        {
            CreateMap<DuenoMuestra, DuenoMuestraDto>()
                .ReverseMap();


            CreateMap<DuenoMuestra, GetDuenoMuestraDto>()
                .ReverseMap();

        }
    }
}
