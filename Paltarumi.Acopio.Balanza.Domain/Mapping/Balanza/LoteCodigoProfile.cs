using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class LoteCodigoProfile : Profile
    {
        public LoteCodigoProfile()
        {
            CreateMap<LoteCodigo, LoteCodigoDto>()
                .ReverseMap();

            CreateMap<LoteCodigo, CreateLoteCodigoDto>()
                .ReverseMap();

            CreateMap<LoteCodigo, UpdateLoteCodigoDto>()
                .ReverseMap();

            CreateMap<LoteCodigo, GetLoteCodigoDto>()
                .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.loteCodigo, opt => opt.MapFrom(x => x.IdLoteNavigation != null ? x.IdLoteNavigation.CodigoLote : string.Empty))
                .ForMember(x => x.NombreDuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.NumeroDuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Numero : string.Empty))
                .ReverseMap();

            CreateMap<LoteCodigo, SearchLoteCodigoDto>()
                .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.loteCodigo, opt => opt.MapFrom(x => x.IdLoteNavigation != null ? x.IdLoteNavigation.CodigoLote : string.Empty))
                .ForMember(x => x.DuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdLoteCodigoEstadoNavigation != null ? x.IdLoteCodigoEstadoNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<LoteCodigo, ListLoteCodigoDto>()
                .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.loteCodigo, opt => opt.MapFrom(x => x.IdLoteNavigation != null ? x.IdLoteNavigation.CodigoLote : string.Empty))
                .ForMember(x => x.DuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation != null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdLoteCodigoEstadoNavigation != null ? x.IdLoteCodigoEstadoNavigation.Nombre : string.Empty))
                .ForMember(x => x.LoteCodigoModulo, opt => opt.MapFrom(x => x.IdModuloNavigation != null ? x.IdModuloNavigation.Nombre : string.Empty))
                .ForMember(x => x.LoteCodigoTipo, opt => opt.MapFrom(x => x.IdLoteCodigoTipoNavigation != null ? x.IdLoteCodigoTipoNavigation.Nombre : string.Empty))
                .ReverseMap();

        }
    }
}
