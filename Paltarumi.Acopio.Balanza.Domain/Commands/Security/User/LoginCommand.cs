using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Security.User
{
    public class LoginCommand : CommandBase<LoginResultDto>
    {
        public LoginCommand(LoginDto loginDto) => LoginDto = loginDto;
        public LoginDto LoginDto { get; set; }
    }
}
