using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteOperacionProfile : Profile
    {
        public LoteOperacionProfile()
        {
            CreateMap<Entity.LoteOperacion, LoteOperacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteOperacion, CreateLoteOperacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteOperacion, UpdateLoteOperacionDto>()
                .ReverseMap();

            CreateMap<Entity.LoteOperacion, GetLoteOperacionDto>()
                .ReverseMap();
        }
    }
}
