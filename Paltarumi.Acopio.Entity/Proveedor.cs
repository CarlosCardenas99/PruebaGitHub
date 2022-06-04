using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Lotes = new HashSet<Lote>();
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

        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<ProveedorConcesion> ProveedorConcesions { get; set; }
    }
}
