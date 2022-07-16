using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class OperacionProfile : Profile
    {
        public OperacionProfile()
        {
            CreateMap<Entity.Operacion, OperacionDto>()
                .ReverseMap();

            CreateMap<Entity.Operacion, CreateOperacionDto>()
                .ReverseMap();

            CreateMap<Entity.Operacion, GetOperacionDto>()
                .ReverseMap();
        }
    }
}
