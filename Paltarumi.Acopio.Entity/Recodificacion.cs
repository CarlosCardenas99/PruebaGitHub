using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Recodificacion
    {
        public int IdRecodificacion { get; set; }
        public int IdLote { get; set; }
        public DateTime FechaRecodificacion { get; set; }
        public string HoraRecodificacion { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string CodigoLaboratorio { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
