using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<Entity.Lote, LoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, CreateLoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, GetLoteDto>()
                .ReverseMap();
        }
    }
}
