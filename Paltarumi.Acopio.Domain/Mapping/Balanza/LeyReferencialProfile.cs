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
                .ReverseMap();
        }
    }
}
