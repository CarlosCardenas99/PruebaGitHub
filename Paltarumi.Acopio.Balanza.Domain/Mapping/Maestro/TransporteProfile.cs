using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class TransporteProfile : Profile
    {
        public TransporteProfile()
        {
            CreateMap<Entity.Transporte, TransporteDto>()
                .ReverseMap();


            CreateMap<Entity.Transporte, GetTransporteDto>()
                .ReverseMap();

        }
    }
}
