using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Lote
    {
        public Lote()
        {
            BlendingLotes = new HashSet<BlendingLote>();
            LoteCodigos = new HashSet<LoteCodigo>();
            LoteOperacions = new HashSet<LoteOperacion>();
        }

        public int IdLote { get; set; }
        public int IdEmpresa { get; set; }
        public string CodigoLote { get; set; } = null!;
        public int IdEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoNavigation { get; set; } = null!;
        public virtual ICollection<BlendingLote> BlendingLotes { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<LoteOperacion> LoteOperacions { get; set; }
    }
}
