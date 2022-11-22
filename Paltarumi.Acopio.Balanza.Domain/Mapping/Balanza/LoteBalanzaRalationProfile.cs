using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class LoteBalanzaRalationProfile : Profile
    {
        public LoteBalanzaRalationProfile()
        {
            CreateMap<LoteBalanzaRalation, LoteBalanzaRalationDto>()
                .ReverseMap();

            CreateMap<LoteBalanzaRalation, CreateLoteBalanzaRalationDto>()
                .ReverseMap();

            CreateMap<LoteBalanzaRalation, UpdateLoteBalanzaRalationDto>()
                .ReverseMap();

            CreateMap<LoteBalanzaRalation, GetLoteBalanzaRalationDto>()
                .ReverseMap();

            CreateMap<LoteBalanzaRalation, ListLoteBalanzaRalationDto>()
               .ForMember(x => x.CodigoLote, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.CodigoLote))
               .ForMember(x => x.FechaAcopio, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.FechaAcopio))
               .ForMember(x => x.FechaIngreso, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.FechaIngreso))
               .ForMember(x => x.Tmh, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.Tmh))
               .ForMember(x => x.Tms, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.Tms))
               .ForMember(x => x.IdProveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdProveedor))
               .ForMember(x => x.IdLoteBalanza, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdLoteBalanza))
               .ForMember(x => x.IdConcesion, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdConcesion))
               .ForMember(x => x.IdEstadoTipoMaterial, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdEstadoTipoMaterial))
               .ForMember(x => x.Tmh100, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.Tmh100))
               .ForMember(x => x.TmhBase, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.TmhBase))
               .ForMember(x => x.Humedad, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.Humedad))
               .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdProveedorNavigation.RazonSocial))
                .ForMember(x => x.NombreConcesion, opt => opt.MapFrom(x => x.IdLoteBalanzaOriginNavigation.IdConcesionNavigation.Nombre))
               .ReverseMap();

        }
    }
}
