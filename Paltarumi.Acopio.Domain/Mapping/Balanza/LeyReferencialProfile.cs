using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class LeyReferencialProfile : Profile
    {
        public LeyReferencialProfile()
        {
            CreateMap<Entity.LeyReferencial, LeyReferencialDto>()
                .ReverseMap();

            CreateMap<Entity.LeyReferencial, CreateLeyReferencialDto>()
                .ReverseMap();

            CreateMap<Entity.LeyReferencial, UpdateLeyReferencialDto>()
                .ReverseMap();

            CreateMap<Entity.LeyReferencial, GetLeyReferencialDto>()
                .ReverseMap();

            CreateMap<Entity.LeyReferencial, SearchLeyReferencialDto>()
                .ForMember(x => x.DuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.TipoMineral, opt => opt.MapFrom(x => x.IdTipoMineralNavigation != null ? x.IdTipoMineralNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
