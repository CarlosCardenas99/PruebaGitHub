using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Conductors = new HashSet<Conductor>();
            Transportes = new HashSet<Transporte>();
        }

        public string CodigoTipoDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? NombreCorto { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<Transporte> Transportes { get; set; }
    }
}
