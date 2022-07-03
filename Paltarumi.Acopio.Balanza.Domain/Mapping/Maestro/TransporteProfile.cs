using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
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
