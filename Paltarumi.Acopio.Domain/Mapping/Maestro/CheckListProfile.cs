using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class CheckListProfile : Profile
    {
        public CheckListProfile()
        {
            CreateMap<Entity.CheckList, CheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, CreateCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, UpdateCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, GetCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, SearchCheckListDto>()
                .ReverseMap();
        }
    }
}
