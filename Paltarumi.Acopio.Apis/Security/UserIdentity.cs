using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Repository.Security;

namespace Paltarumi.Acopio.Apis.Security
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public string GetCurrentUser() =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? Constants.Security.User.Admin;
    }
}
