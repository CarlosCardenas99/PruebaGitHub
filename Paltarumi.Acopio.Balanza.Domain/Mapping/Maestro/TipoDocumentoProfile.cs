using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile()
        {
            CreateMap<TipoDocumento, TipoDocumentoDto>()
                .ReverseMap();

            CreateMap<TipoDocumento, GetTipoDocumentoDto>()
                .ReverseMap();

            CreateMap<TipoDocumento, ListTipoDocumentoDto>()
                .ReverseMap();

        }
    }
}
