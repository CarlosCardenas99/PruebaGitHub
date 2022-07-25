using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class LoteBalanzaProfile : Profile
    {
        public LoteBalanzaProfile()
        {
            CreateMap<Entity.LoteBalanza, LoteBalanzaDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, CreateLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, UpdateLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, GetLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, GetLoteBalanzaCodigoDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, GetLoteBalanzaCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, ListLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<Entity.LoteBalanza, SearchLoteBalanzaDto>()
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdEstadoNavigation != null ? x.IdEstadoNavigation.Descripcion : string.Empty))
                .ForMember(x => x.CodigoEstado, opt => opt.MapFrom(x => x.IdEstadoNavigation != null ? x.IdEstadoNavigation.CodigoItem : string.Empty))
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.NombreEstadoTipoMaterial, opt => opt.MapFrom(x => x.IdEstadoTipoMaterialNavigation != null ? x.IdEstadoTipoMaterialNavigation.Descripcion : string.Empty))
                .ForMember(x => x.NumeroTickets, opt => opt.MapFrom(x => x.Tickets != null ? string.Join(", ", x.Tickets.Select(x => x.Numero)) : string.Empty))
                .ReverseMap();
            
            CreateMap<Entity.LoteBalanza, SearchLoteBalanzaChecklistDto>()
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdEstadoNavigation != null ? x.IdEstadoNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
