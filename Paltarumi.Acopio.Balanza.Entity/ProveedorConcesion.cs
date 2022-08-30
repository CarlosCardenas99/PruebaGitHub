using Paltarumi.Acopio.Balanza.Entity.Audit;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class ProveedorConcesion
    {
        public int IdProveedorConcesion { get; set; }
        public int IdProveedor { get; set; }
        public int IdConcesion { get; set; }
        public bool Activo { get; set; }

        public virtual Concesion IdConcesionNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
    }
}
