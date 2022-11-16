using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Acopio.LoteEstado;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteEstadoProfile : Profile
    {
        public LoteEstadoProfile()
        {
            CreateMap<LoteEstado, LoteEstadoDto>()
                .ReverseMap();

            CreateMap<LoteEstado, GetLoteEstadoDto>()
                .ReverseMap();
        }
    }
}
