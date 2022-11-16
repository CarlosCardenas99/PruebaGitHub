using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Muestreo
{
    public class LoteCodigoMuestreoProfile : Profile
    {
        public LoteCodigoMuestreoProfile()
        {
            CreateMap<LoteCodigoMuestreo, LoteCodigoMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteCodigoMuestreo, CreateLoteCodigoMuestreoDto>()
                .ReverseMap();

            CreateMap<LoteCodigoMuestreo, UpdateLoteCodigoMuestreoDto>()
                .ReverseMap();
        }
    }
}
