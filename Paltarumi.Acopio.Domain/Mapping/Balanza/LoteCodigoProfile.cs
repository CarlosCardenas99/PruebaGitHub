using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class LoteCodigoProfile : Profile
    {
        public LoteCodigoProfile()
        {
            CreateMap<Entity.LoteCodigo, LoteCodigoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigo, CreateLoteCodigoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigo, UpdateLoteCodigoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigo, GetLoteCodigoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCodigo, SearchLoteCodigoDto>()
                 .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? (x.IdLoteBalanzaNavigation.IdProveedorNavigation != null ? x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial : string.Empty) : string.Empty))
                 .ForMember(x => x.loteCodigo, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.Codigo : string.Empty))
                 .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.IdEstadoNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
