using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Muestreo
{
    public class LoteMuestreoProfile : Profile
    {
        public LoteMuestreoProfile()
        {
            CreateMap<Entity.LoteMuestreo, LoteMuestreoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteMuestreo, CreateLoteMuestreoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteMuestreo, GetLoteMuestreoDto>()
                .ReverseMap();
        }
    }
}
