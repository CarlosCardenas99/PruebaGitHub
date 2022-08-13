using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoNomenclatura
    {
        public int IdLoteCodigoNomenclatura { get; set; }
        public string IdLoteCodigoTipo { get; set; } = null!;
        public int? IdEmpresa { get; set; }
        public string TipoLoteCodigoNomenclatura { get; set; } = null!;
        public string? EmpresaNomenclatura { get; set; }
        public bool Activo { get; set; }

        public virtual Empresa? IdEmpresaNavigation { get; set; }
        public virtual LoteCodigoTipo IdLoteCodigoTipoNavigation { get; set; } = null!;
    }
}
