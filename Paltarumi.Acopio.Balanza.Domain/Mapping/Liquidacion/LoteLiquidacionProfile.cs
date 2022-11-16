using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Liquidacion
{
    public class LoteLiquidacionProfile : Profile
    {
        public LoteLiquidacionProfile()
        {
            CreateMap<LoteLiquidacion, LoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<LoteLiquidacion, CreateLoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<LoteLiquidacion, UpdateLoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<LoteLiquidacion, GetLoteLiquidacionDto>()
                .ReverseMap();
        }
    }
}
