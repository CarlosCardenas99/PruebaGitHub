using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
{
    public class RecodificacionProfile : Profile
    {
        public RecodificacionProfile()
        {
            CreateMap<Entity.Recodificacion, RecodificacionDto>()
                .ReverseMap();

            CreateMap<Entity.Recodificacion, CreateRecodificacionDto>()
                .ReverseMap();

            CreateMap<Entity.Recodificacion, UpdateRecodificacionDto>()
                .ReverseMap();

            CreateMap<Entity.Recodificacion, GetRecodificacionDto>()
                .ReverseMap();

            CreateMap<Entity.Recodificacion, SearchRecodificacionDto>()
                .ReverseMap();
        }
    }
}
