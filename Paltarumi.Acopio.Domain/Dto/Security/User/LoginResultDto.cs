using Paltarumi.Acopio.Domain.Dto.Security.Token;

namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class LoginResultDto
    {
        public AccessTokenDto? AccessToken { get; set; }
    }
}
