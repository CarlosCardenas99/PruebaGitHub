using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteOperacionProfile : Profile
    {
        public LoteOperacionProfile()
        {
            CreateMap<LoteOperacion, LoteOperacionDto>()
                .ReverseMap();

            CreateMap<LoteOperacion, CreateLoteOperacionDto>()
                .ReverseMap();

            CreateMap<LoteOperacion, UpdateLoteOperacionDto>()
                .ReverseMap();

            CreateMap<LoteOperacion, GetLoteOperacionDto>()
                .ReverseMap();
        }
    }
}
