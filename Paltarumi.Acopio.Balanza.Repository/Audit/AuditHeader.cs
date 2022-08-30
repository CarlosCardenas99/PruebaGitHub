using Paltarumi.Acopio.Balanza.Repository.Abstractions.Audit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paltarumi.Acopio.Balanza.Repository.Audit
{
    [Table("AuditHeader")]
    public class AuditHeader
    {
        public AuditHeader() => AuditDetails = new HashSet<AuditDetail>();

        [Key]
        public Guid Id { get; set; }
        public Operation Operation { get; set; }
        [MaxLength(255)]
        public string Entity { get; set; } = null!;
        [MaxLength(255)]
        public string Identifier { get; set; } = null!;
        [MaxLength(255)]
        public string UserName { get; set; } = null!;
        public DateTimeOffset Date { get; set; }

        public virtual ICollection<AuditDetail> AuditDetails { get; set; }
    }
}
