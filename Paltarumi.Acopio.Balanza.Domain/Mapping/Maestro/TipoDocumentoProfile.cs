using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile()
        {
            CreateMap<Entity.TipoDocumento, TipoDocumentoDto>()
                .ReverseMap();

            CreateMap<Entity.TipoDocumento, GetTipoDocumentoDto>()
                .ReverseMap();

            CreateMap<Entity.TipoDocumento, ListTipoDocumentoDto>()
                .ReverseMap();

        }
    }
}
