using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class ItemCheckProfile : Profile
    {
        public ItemCheckProfile()
        {
            CreateMap<Entity.ItemCheck, ItemCheckDto>()
                .ReverseMap();

            CreateMap<Entity.ItemCheck, CreateItemCheckDto>()
                .ReverseMap();

            CreateMap<Entity.ItemCheck, UpdateItemCheckDto>()
                .ReverseMap();

            CreateMap<Entity.ItemCheck, GetItemCheckDto>()
                .ReverseMap();

            CreateMap<Entity.ItemCheck, ListItemCheckDto>()
                .ReverseMap();

            CreateMap<Entity.ItemCheck, SearchItemCheckDto>()
                .ReverseMap();
        }
    }
}
