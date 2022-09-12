using Paltarumi.Acopio.Audit.Entity.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class Concesion
    {
        public Concesion()
        {
            LoteBalanzas = new HashSet<LoteBalanza>();
            ProveedorConcesions = new HashSet<ProveedorConcesion>();
        }

        public int IdConcesion { get; set; }
        public string CodigoUnico { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public bool Activo { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<LoteBalanza> LoteBalanzas { get; set; }
        public virtual ICollection<ProveedorConcesion> ProveedorConcesions { get; set; }
    }
}
