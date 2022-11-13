using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Costo
    {
        public int IdCosto { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string IdCostoConcepto { get; set; } = null!;
        public string IdUnidadMedida { get; set; } = null!;
        public string IdDivisa { get; set; } = null!;
        public decimal ValorUnitario100 { get; set; }
        public decimal ValorUnitario { get; set; }
        public string? Observacion { get; set; }
        public bool Activo { get; set; }

        public virtual CostoConcepto IdCostoConceptoNavigation { get; set; } = null!;
        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual UnidadMedidum IdUnidadMedidaNavigation { get; set; } = null!;
    }
}
