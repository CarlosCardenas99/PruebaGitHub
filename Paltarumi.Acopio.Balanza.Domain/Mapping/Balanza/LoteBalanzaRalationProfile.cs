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

        }
    }
}
