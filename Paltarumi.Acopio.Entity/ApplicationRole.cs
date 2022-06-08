using Microsoft.AspNetCore.Identity;

namespace Paltarumi.Acopio.Entity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public bool Activo { get; set; }
    }
}
