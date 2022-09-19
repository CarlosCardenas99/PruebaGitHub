using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Repository.Security;
using System.Security.Claims;

namespace Paltarumi.Acopio.Balanza.Apis.Security
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public IEnumerable<Claim> GetCurrentUserClaims()
            => _httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();

        private string GetUserNameClaim()
            => GetCurrentUserClaims()?.FirstOrDefault(x => x.Type == "DisplayName" || x.Type == "UserName")?.Value!;

        public string GetCurrentUser()
            => GetUserNameClaim() ?? Constants.Security.User.Admin;

        public int? GetCurrentUserId()
        {
            var userId = default(int?);
            var userIdClaim = GetCurrentUserClaims().FirstOrDefault(x => x.Type == "UserId")?.Value;
            if (userIdClaim != null) userId = int.Parse(userIdClaim);
            return userId;
        }
    }
}
