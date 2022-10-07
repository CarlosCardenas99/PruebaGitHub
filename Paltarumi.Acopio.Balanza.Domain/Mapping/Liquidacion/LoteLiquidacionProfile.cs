using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Liquidacion
{
    public class LoteLiquidacionProfile : Profile
    {
        public LoteLiquidacionProfile()
        {
            CreateMap<Entity.LoteLiquidacion, LoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteLiquidacion, CreateLoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteLiquidacion, UpdateLoteLiquidacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteLiquidacion, GetLoteLiquidacionDto>()
                .ReverseMap();
        }
    }
}
