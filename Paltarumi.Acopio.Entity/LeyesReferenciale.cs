using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LeyesReferenciale
    {
        public int IdLeyesReferenciales { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int IdDuenoMuestra { get; set; }
        public string CodigoMuestra { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public int CodigoLaboratorio { get; set; }
        public bool Activo { get; set; }
    }
}
