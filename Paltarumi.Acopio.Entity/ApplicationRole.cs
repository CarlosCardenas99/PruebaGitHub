using Microsoft.AspNetCore.Identity;

namespace Paltarumi.Acopio.Entity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public bool Activo { get; set; }
    }
}
