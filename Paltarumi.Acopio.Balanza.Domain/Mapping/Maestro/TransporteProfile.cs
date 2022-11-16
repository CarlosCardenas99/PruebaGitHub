using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class TransporteProfile : Profile
    {
        public TransporteProfile()
        {
            CreateMap<Transporte, TransporteDto>()
                .ReverseMap();

            CreateMap<Transporte, GetTransporteDto>()
                .ReverseMap();
        }
    }
}
