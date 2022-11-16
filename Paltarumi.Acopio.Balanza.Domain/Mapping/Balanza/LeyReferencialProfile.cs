using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class LeyReferencialProfile : Profile
    {
        public LeyReferencialProfile()
        {
            CreateMap<LeyReferencial, LeyReferencialDto>()
                .ReverseMap();

            CreateMap<LeyReferencial, CreateLeyReferencialDto>()
                .ReverseMap();

            CreateMap<LeyReferencial, UpdateLeyReferencialDto>()
                .ReverseMap();

            CreateMap<LeyReferencial, GetLeyReferencialDto>()
                .ReverseMap();

            CreateMap<LeyReferencial, SearchLeyReferencialDto>()
                .ForMember(x => x.DuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.TipoMineral, opt => opt.MapFrom(x => x.IdTipoMineralNavigation != null ? x.IdTipoMineralNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
