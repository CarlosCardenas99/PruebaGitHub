using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Security.Token;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Domain.Commands.Security.Token
{
    public class GenerateTokenCommand : CommandBase<AccessTokenDto>
    {
        public GenerateTokenCommand(ApplicationUser user) => User = user;
        public ApplicationUser User { get; set; }
    }
}
