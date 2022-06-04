using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Concesion
    {
        public Concesion()
        {
            Lotes = new HashSet<Lote>();
            ProveedorConcesions = new HashSet<ProveedorConcesion>();
        }

        public int IdConcesion { get; set; }
        public string CodigoUnico { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<ProveedorConcesion> ProveedorConcesions { get; set; }
    }
}
