using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Repository.Audit;

namespace Paltarumi.Acopio.Balanza.Repository.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext()
        {

        }

        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AuditDetail> AuditDetails { get; set; } = null!;
        public virtual DbSet<AuditHeader> AuditHeaders { get; set; } = null!;
    }
}
