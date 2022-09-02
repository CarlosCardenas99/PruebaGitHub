using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteEstadoProfile : Profile
    {
        public LoteEstadoProfile()
        {
            CreateMap<Entity.LoteEstado, LoteEstadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteEstado, GetLoteEstadoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteEstado, SelectComboLoteEstadoDto>()
                .ReverseMap();
        }
    }
}
