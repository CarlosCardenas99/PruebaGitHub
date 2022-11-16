using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<Lote, LoteDto>()
                .ReverseMap();

            CreateMap<Lote, CreateLoteDto>()
                .ReverseMap();

            CreateMap<Lote, GetLoteDto>()
                .ReverseMap();
        }
    }
}
