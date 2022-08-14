using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
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
                .ForMember(x => x.loteCodigo, opt => opt.MapFrom(x => x.IdLoteNavigation != null ? x.IdLoteNavigation.CodigoLote : string.Empty))
                .ForMember(x => x.DuenoMuestra, opt => opt.MapFrom(x => x.IdDuenoMuestraNavigation!= null ? x.IdDuenoMuestraNavigation.Nombres : string.Empty))
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.IdLoteCodigoEstadoNavigation != null ? x.IdLoteCodigoEstadoNavigation.Nombre : string.Empty))
                .ReverseMap();
        }
    }
}
