using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Correlativo
    {
        public Correlativo()
        {
            LoteBalanzas = new HashSet<LoteBalanza>();
            LoteChancados = new HashSet<LoteChancado>();
            LoteCodigos = new HashSet<LoteCodigo>();
            LoteLiquidacions = new HashSet<LoteLiquidacion>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
        }

        public int IdCorrelativo { get; set; }
        public int IdEmpresa { get; set; }
        public string IdSucursal { get; set; } = null!;
        public string CodigoCorrelativoTipo { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public int Numero { get; set; }
        public bool Activo { get; set; }

        public virtual CorrelativoTipo CodigoCorrelativoTipoNavigation { get; set; } = null!;
        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        public virtual ICollection<LoteBalanza> LoteBalanzas { get; set; }
        public virtual ICollection<LoteChancado> LoteChancados { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<LoteLiquidacion> LoteLiquidacions { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
    }
}
