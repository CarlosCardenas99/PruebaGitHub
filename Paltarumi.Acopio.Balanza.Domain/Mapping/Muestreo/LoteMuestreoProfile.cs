using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Muestreo
{
    public class LoteMuestreoProfile : Profile
    {
        public LoteMuestreoProfile()
        {
            CreateMap<LoteMuestreo, LoteMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteMuestreo, CreateLoteMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteMuestreo, GetLoteMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteMuestreo, UpdateLoteMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteMuestreo, UpdateEstadoLoteMuestreoDto>()
               .ReverseMap();
        }
    }
}
