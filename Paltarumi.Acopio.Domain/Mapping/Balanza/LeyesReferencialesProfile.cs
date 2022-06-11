using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class LeyesReferencialesProfile : Profile
    {
        public LeyesReferencialesProfile()
        {
            CreateMap<Entity.LeyesReferenciales, LeyesReferencialesDto>()
                .ReverseMap();

            CreateMap<Entity.LeyesReferenciales, CreateLeyesReferencialesDto>()
                .ReverseMap();

            CreateMap<Entity.LeyesReferenciales, UpdateLeyesReferencialesDto>()
                .ReverseMap();

            CreateMap<Entity.LeyesReferenciales, GetLeyesReferencialesDto>()
                .ReverseMap();

            CreateMap<Entity.LeyesReferenciales, SearchLeyesReferencialesDto>()
                .ReverseMap();
        }
    }
}
