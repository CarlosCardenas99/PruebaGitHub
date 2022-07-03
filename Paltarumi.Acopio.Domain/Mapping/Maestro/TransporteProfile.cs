using AutoMapper;
using Paltarumi.Acopio.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class TransporteProfile : Profile
    {
        public TransporteProfile()
        {
            CreateMap<Entity.Transporte, TransporteDto>()
                .ReverseMap();

            CreateMap<Entity.Transporte, CreateTransporteDto>()
                .ReverseMap();

            CreateMap<Entity.Transporte, UpdateTransporteDto>()
                .ReverseMap();

            CreateMap<Entity.Transporte, GetTransporteDto>()
                .ReverseMap();

            CreateMap<Entity.Transporte, SearchTransporteDto>()
                .ReverseMap();
        }
    }
}
