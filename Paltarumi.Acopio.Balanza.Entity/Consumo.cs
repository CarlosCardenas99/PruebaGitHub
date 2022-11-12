using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Consumo
    {
        public int IdConsumo { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string IdInsumo { get; set; } = null!;
        public string IdUnidadMedida { get; set; } = null!;
        public string IdDivisa { get; set; } = null!;
        public decimal Precio100 { get; set; }
        public decimal Precio { get; set; }
        public string? Observacion { get; set; }
        public bool Activo { get; set; }

        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual Insumo IdInsumoNavigation { get; set; } = null!;
        public virtual UnidadMedidum IdUnidadMedidaNavigation { get; set; } = null!;
    }
}
