using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Muestreo
{
    public class LoteCodigoMuestreoProfile : Profile
    {
        public LoteCodigoMuestreoProfile()
        {
            CreateMap<Entity.LoteCodigoMuestreo, LoteCodigoMuestreoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigoMuestreo, CreateLoteCodigoMuestreoDto>()
                .ReverseMap();

            //CreateMap<Entity.LoteCodigoMuestreo, UpdateLoteCodigoMuestreoDto>()
            //    .ReverseMap();

            //CreateMap<Entity.LoteCodigoMuestreo, GetLoteCodigoMuestreoDto>()
            //    .ReverseMap();

            //CreateMap<Entity.LoteCodigoMuestreo, ListLoteCodigoMuestreoDto>()
            //    .ReverseMap();

            //CreateMap<Entity.LoteCodigoMuestreo, SearchLoteCodigoMuestreoDto>()
            //    .ReverseMap();
        }
    }
}
