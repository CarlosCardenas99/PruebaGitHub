using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Chancado
{
    public class LoteChancadoProfile : Profile
    {
        public LoteChancadoProfile()
        {
            CreateMap<LoteChancado, LoteChancadoDto>()
                .ReverseMap();

            CreateMap<LoteChancado, CreateLoteChancadoDto>()
                .ReverseMap();

            CreateMap<LoteChancado, GetLoteChancadoDto>()
                .ReverseMap();

            CreateMap<LoteChancado, UpdateLoteChancadoDto>()
                .ReverseMap();

            CreateMap<LoteChancado, UpdateEstadoLoteChancadoDto>()
               .ReverseMap();
        }
    }
}
