using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Correlativo
    {
        public int IdCorrelativo { get; set; }
        public int IdEmpresa { get; set; }
        public string CodigoCorrelativoTipo { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public int Numero { get; set; }
        public bool Activo { get; set; }

        public virtual CorrelativoTipo CodigoCorrelativoTipoNavigation { get; set; } = null!;
        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
    }
}
