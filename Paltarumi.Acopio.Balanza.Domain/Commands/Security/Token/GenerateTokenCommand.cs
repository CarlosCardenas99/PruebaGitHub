using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Entity;
using Paltarumi.Acopio.Security.Dto.Token;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Security.Token
{
    public class GenerateTokenCommand : CommandBase<AccessTokenDto>
    {
        public GenerateTokenCommand(ApplicationUser user) => User = user;
        public ApplicationUser User { get; set; }
    }
}
