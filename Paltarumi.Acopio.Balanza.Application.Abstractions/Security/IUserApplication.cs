using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Security
{
    public interface IUserApplication
    {
        Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto);
        Task<ResponseDto> Login(LoginDto loginDto);
    }
}
