using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class DuenoMuestra
    {
        public DuenoMuestra()
        {
            LeyReferencials = new HashSet<LeyReferencial>();
        }

        public int IdDuenoMuestra { get; set; }
        public int? IdProveedor { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Proveedor? IdProveedorNavigation { get; set; }
        public virtual ICollection<LeyReferencial> LeyReferencials { get; set; }
    }
}
