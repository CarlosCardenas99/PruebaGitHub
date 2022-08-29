using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paltarumi.Acopio.Balanza.Repository.Audit
{
    [Table("AuditDetail")]
    public class AuditDetail
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("AuditHeaderId")]
        public AuditHeader AuditHeader { get; set; } = null!;
        public Guid AuditHeaderId { get; set; }
        [MaxLength(255)]
        public string Field { get; set; } = null!;
        public string? Value { get; set; } = null!;
    }
}
