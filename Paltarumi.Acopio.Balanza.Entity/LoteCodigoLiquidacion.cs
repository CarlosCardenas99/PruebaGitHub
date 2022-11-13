using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoLiquidacion
    {
        public int IdLoteCodigoLiquidacion { get; set; }
        public int? IdLoteCodigo { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public string IdLoteCodigoTipo { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string? IdTipoProporcion { get; set; }
        public string IdTipoMetal { get; set; } = null!;
        public DateTimeOffset FechaRecepcion { get; set; }
        public float? LeyAuOzTcFinoNewmont { get; set; }
        public float? LeyAuOzTcGruesoNewmont { get; set; }
        public decimal LeyOzTc100Newmont { get; set; }
        public decimal LeyOzTcBaseNewmont { get; set; }
        public decimal LeyOzTcNewmont { get; set; }
        public decimal PorcentajeDilucion { get; set; }
        public string Adjunto { get; set; } = null!;
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual LoteCodigo? IdLoteCodigoNavigation { get; set; }
        public virtual LoteCodigoTipo IdLoteCodigoTipoNavigation { get; set; } = null!;
        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
        public virtual TipoMetal IdTipoMetalNavigation { get; set; } = null!;
        public virtual TipoProporcion? IdTipoProporcionNavigation { get; set; }
    }
}
