using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Repository.Data
{
    public class SecurityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}
