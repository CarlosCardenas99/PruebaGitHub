using System.Security.Claims;

namespace Paltarumi.Acopio.Repository.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
