using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Asignacion
    {
        public Asignacion()
        {
            LoteLiquidacionAsignacions = new HashSet<LoteLiquidacionAsignacion>();
            LoteLiquidacionComisionAsignacions = new HashSet<LoteLiquidacionComisionAsignacion>();
        }

        public int IdAsignacion { get; set; }
        public decimal TipoCambio { get; set; }
        public string IdDivisa { get; set; } = null!;
        public decimal SubTotalEmpresa { get; set; }
        public decimal SubTotalProveedor { get; set; }
        public decimal SubTotal { get; set; }
        public string? Observacion { get; set; }
        public bool Activo { get; set; }

        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionAsignacion> LoteLiquidacionAsignacions { get; set; }
        public virtual ICollection<LoteLiquidacionComisionAsignacion> LoteLiquidacionComisionAsignacions { get; set; }
    }
}
