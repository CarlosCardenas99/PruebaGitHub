using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class AuditDetail
    {
        public Guid Id { get; set; }
        public Guid AuditHeaderId { get; set; }
        public string Field { get; set; } = null!;
        public string? Value { get; set; }

        public virtual AuditHeader AuditHeader { get; set; } = null!;
    }
}
