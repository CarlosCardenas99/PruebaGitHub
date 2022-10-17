using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Chancado
{
    public class LoteChancadoProfile : Profile
    {
        public LoteChancadoProfile()
        {
            CreateMap<Entity.LoteChancado, LoteChancadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteChancado, CreateLoteChancadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteChancado, GetLoteChancadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteChancado, UpdateLoteChancadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteChancado, UpdateEstadoLoteChancadoDto>()
               .ReverseMap();
        }
    }
}
