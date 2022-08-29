using System.Security.Claims;

namespace Paltarumi.Acopio.Balanza.Repository.Abstractions.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
