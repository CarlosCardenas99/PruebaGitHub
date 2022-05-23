using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<Entity.Lote, LoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, CreateLoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, UpdateLoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, GetLoteDto>()
                .ReverseMap();

            CreateMap<Entity.Lote, ListLoteDto>()
                .ForMember(x => x.ProveedorRazonSocial, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ReverseMap();
        }
    }
}
