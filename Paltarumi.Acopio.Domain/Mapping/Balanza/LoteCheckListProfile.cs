using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
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

            CreateMap<Entity.LoteCheckList, SearchLoteCheckListDto>()
                .ReverseMap();
        }
    }
}
