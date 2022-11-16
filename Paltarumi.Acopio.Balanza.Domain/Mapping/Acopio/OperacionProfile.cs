using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class OperacionProfile : Profile
    {
        public OperacionProfile()
        {
            CreateMap<Operacion, OperacionDto>()
                .ReverseMap();

            CreateMap<Operacion, CreateOperacionDto>()
                .ReverseMap();

            CreateMap<Operacion, GetOperacionDto>()
                .ReverseMap();
        }
    }
}
