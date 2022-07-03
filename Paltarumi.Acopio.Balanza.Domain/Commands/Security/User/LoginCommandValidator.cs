using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Security.User
{
    public class LoginCommandValidator : CommandValidatorBase<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RequiredInformation(x => x.LoginDto).DependentRules(() =>
            {
                RequiredString(x => x.LoginDto.UserName, Resources.Security.User.UserName, 6, 255);
                RequiredString(x => x.LoginDto.Password, Resources.Security.User.Password, 2, 100);
            });
        }
    }
}
