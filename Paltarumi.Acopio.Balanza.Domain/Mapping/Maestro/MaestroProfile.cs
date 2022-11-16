using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class MaestroProfile : Profile
    {
        public MaestroProfile()
        {
            CreateMap<Paltarumi.Acopio.Entity.Maestro, MaestroDto>()
                .ReverseMap();

            CreateMap<Paltarumi.Acopio.Entity.Maestro, GetMaestroDto>()
                .ReverseMap();

            CreateMap<Paltarumi.Acopio.Entity.Maestro, ListMaestroDto>()
                .ReverseMap();
        }
    }
}
