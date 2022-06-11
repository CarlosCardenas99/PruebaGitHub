using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Ubigeo
    {
        public Ubigeo()
        {
            Conductors = new HashSet<Conductor>();
            Proveedors = new HashSet<Proveedor>();
            Transportes = new HashSet<Transporte>();
            Transportista = new HashSet<Transportistum>();
        }

        public string CodigoUbigeo { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        public virtual ICollection<Transporte> Transportes { get; set; }
        public virtual ICollection<Transportistum> Transportista { get; set; }
    }
}
