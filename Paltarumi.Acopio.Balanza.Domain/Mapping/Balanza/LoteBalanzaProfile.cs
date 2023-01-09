using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Dto;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class LoteBalanzaProfile : Profile
    {
        public LoteBalanzaProfile()
        {
            CreateMap<LoteBalanza, LoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, CreateLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, UpdateLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, UpdateTmsLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, UpdateCodigoTrujilloLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, GetLoteBalanzaDto>()
                .ReverseMap();



            CreateMap<LoteBalanza, GetLoteBalanzaCodigoDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, GetLoteBalanzaCheckListDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, ListLoteBalanzaDto>()
                .ReverseMap();

            CreateMap<LoteBalanza, SearchLoteBalanzaDto>()
                .ForMember(x => x.LoteEstado, opt => opt.MapFrom(x => x.IdLoteEstadoNavigation != null ? x.IdLoteEstadoNavigation.Nombre : string.Empty))
                .ForMember(x => x.IdLoteEstado, opt => opt.MapFrom(x => x.IdLoteEstadoNavigation != null ? x.IdLoteEstadoNavigation.IdLoteEstado : string.Empty))
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.NombreEstadoTipoMaterial, opt => opt.MapFrom(x => x.IdEstadoTipoMaterialNavigation != null ? x.IdEstadoTipoMaterialNavigation.Descripcion : string.Empty))
                .ForMember(x => x.NumeroTickets, opt => opt.MapFrom(x => x.Tickets != null ? string.Join(", ", x.Tickets.Select(x => x.Numero)) : string.Empty))
                .ReverseMap();

            CreateMap<LoteBalanza, SearchLoteBalanzaPruebaDto>()
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation != null ? x.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdConcesionNavigation != null ? x.IdConcesionNavigation.Nombre : string.Empty))

                .ReverseMap();

            CreateMap<LoteBalanza, SearchLoteBalanzaChecklistDto>()
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdLoteEstadoNavigation != null ? x.IdLoteEstadoNavigation.Nombre : string.Empty))
                .ReverseMap();

            CreateMap<LoteBalanza, SearchLoteBalanzaRalationDto>()
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation.RazonSocial))
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdConcesionNavigation.Nombre))
                .ReverseMap();

            CreateMap<LoteBalanza, SelectLoteBalanzaRalationDto>()
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdProveedorNavigation.RazonSocial))
                .ReverseMap();
        }
    }
}
