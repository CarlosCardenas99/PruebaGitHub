using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Lote
    {
        public Lote()
        {
            LoteOperacions = new HashSet<LoteOperacion>();
        }

        public int IdLote { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }

        public virtual ICollection<LoteOperacion> LoteOperacions { get; set; }
    }
}
