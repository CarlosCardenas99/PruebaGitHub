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
                .ReverseMap();

            CreateMap<Entity.Lote, SearchLoteDto>()
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.NombreEstadoTipoMaterial, opt => opt.MapFrom(x => x.IdEstadoTipoMaterialNavigation != null ? x.IdEstadoTipoMaterialNavigation.Descripcion : string.Empty))
                .ForMember(x => x.NumeroTickets, opt => opt.MapFrom(x => x.Tickets != null ? string.Join(",", x.Tickets.Select(x => x.Numero)) : string.Empty))
                .ReverseMap();
        }
    }
}
