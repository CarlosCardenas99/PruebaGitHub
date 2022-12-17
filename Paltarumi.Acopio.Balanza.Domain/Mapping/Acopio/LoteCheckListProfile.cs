using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Acopio
{
    public class LoteCheckListProfile : Profile
    {
        public LoteCheckListProfile()
        {
            CreateMap<Entity.LoteCheckList, LoteCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCheckList, CreateLoteCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCheckList, UpdateLoteCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.LoteCheckList, GetLoteCheckListDto>()
                .ReverseMap();
        }
    }
}
