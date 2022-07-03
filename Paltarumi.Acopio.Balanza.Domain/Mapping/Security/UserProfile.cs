using AutoMapper;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Security
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entity.ApplicationUser, UserDto>()
                .ReverseMap();

            CreateMap<Entity.ApplicationUser, CreateUserDto>()
                .ReverseMap();

            CreateMap<Entity.ApplicationUser, UpdateUserDto>()
                .ReverseMap();

            CreateMap<Entity.ApplicationUser, GetUserDto>()
                .ReverseMap();

            CreateMap<Entity.ApplicationUser, ListUserDto>()
                .ReverseMap();

            CreateMap<Entity.ApplicationUser, SearchUserDto>()
                .ReverseMap();
        }
    }
}
