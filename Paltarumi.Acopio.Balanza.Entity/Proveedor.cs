using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Comprobantes = new HashSet<Comprobante>();
            LoteBalanzas = new HashSet<LoteBalanza>();
            LoteChancados = new HashSet<LoteChancado>();
            LoteCodigos = new HashSet<LoteCodigo>();
            LoteLiquidacions = new HashSet<LoteLiquidacion>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
            ProveedorConcesions = new HashSet<ProveedorConcesion>();
        }

        public int IdProveedor { get; set; }
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Ubigeo? CodigoUbigeoNavigation { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzas { get; set; }
        public virtual ICollection<LoteChancado> LoteChancados { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<LoteLiquidacion> LoteLiquidacions { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
        public virtual ICollection<ProveedorConcesion> ProveedorConcesions { get; set; }
    }
}
