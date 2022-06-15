using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;

namespace Paltarumi.Acopio.Domain.Commands.Security.User
{
    public class LoginCommand : CommandBase<LoginResultDto>
    {
        public LoginCommand(LoginDto loginDto) => LoginDto = loginDto;
        public LoginDto LoginDto { get; set; }
    }
}
