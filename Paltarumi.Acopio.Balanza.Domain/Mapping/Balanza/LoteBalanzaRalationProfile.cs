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

            CreateMap<LoteBalanzaRalation, SearchLoteBalanzaRalationDto>()
                .ForMember(x => x.CodigoLote, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.CodigoLote))
                .ForMember(x => x.FechaAcopio, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.FechaAcopio))
                .ForMember(x => x.FechaIngreso, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.FechaIngreso))
                .ForMember(x => x.Tmh, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.Tmh))
                .ForMember(x => x.Tms, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.Tms))
                .ForMember(x => x.IdProveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.IdProveedor))
                .ForMember(x => x.IdLoteBalanza, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.IdLoteBalanza))
                .ForMember(x => x.IdConcesion, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.IdConcesion))
                .ForMember(x => x.IdEstadoTipoMaterial, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.IdEstadoTipoMaterial))
                .ForMember(x => x.Tmh100, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.Tmh100))
                .ForMember(x => x.TmhBase, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.TmhBase))
                .ForMember(x => x.Humedad, opt => opt.MapFrom(x => x.IdLoteBalanzaDestinationNavigation.Humedad))
                .ReverseMap();
        }
    }
}
