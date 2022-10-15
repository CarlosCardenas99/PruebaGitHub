using System.Security.Claims;

namespace Paltarumi.Acopio.Balanza.Repository.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetIdSucursal();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
