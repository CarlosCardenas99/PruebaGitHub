using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoNomenclatura
    {
        public int IdLoteCodigoNomenclatura { get; set; }
        public bool EsInterno { get; set; }
        public int IdTipoLoteCodigo { get; set; }
        public int? IdEmpresa { get; set; }
        public string EsInternoNomenclatura { get; set; } = null!;
        public string TipoLoteCodigoNomenclatura { get; set; } = null!;
        public string? EmpresaNomenclatura { get; set; }
        public bool Activo { get; set; }

        public virtual Empresa? IdEmpresaNavigation { get; set; }
        public virtual Maestro IdTipoLoteCodigoNavigation { get; set; } = null!;
    }
}
