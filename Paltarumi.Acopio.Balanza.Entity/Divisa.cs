using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Divisa
    {
        public Divisa()
        {
            Asignacions = new HashSet<Asignacion>();
            Comprobantes = new HashSet<Comprobante>();
            LoteLiquidacionComisions = new HashSet<LoteLiquidacionComision>();
            TipoCostos = new HashSet<TipoCosto>();
        }

        public string IdDivisa { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<LoteLiquidacionComision> LoteLiquidacionComisions { get; set; }
        public virtual ICollection<TipoCosto> TipoCostos { get; set; }
    }
}
