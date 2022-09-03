using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class AuditHeader
    {
        public AuditHeader()
        {
            AuditDetails = new HashSet<AuditDetail>();
        }

        public Guid Id { get; set; }
        public int Operation { get; set; }
        public string Entity { get; set; } = null!;
        public string Identifier { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTimeOffset Date { get; set; }

        public virtual ICollection<AuditDetail> AuditDetails { get; set; }
    }
}
