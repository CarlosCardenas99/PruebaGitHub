using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Paltarumi.Acopio.Balanza.Apis.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeAttribute(params string[] roles)
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
