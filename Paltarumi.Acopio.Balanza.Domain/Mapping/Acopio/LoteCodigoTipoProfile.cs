using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteCodigoTipoProfile : Profile
    {
        public LoteCodigoTipoProfile()
        {
            CreateMap<Entity.LoteCodigoTipo, LoteCodigoTipoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigoTipo, SelectComboLoteCodigoTipoDto>()
                .ReverseMap();

        }
    }
}
