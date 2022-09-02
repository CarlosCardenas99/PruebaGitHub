using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteEstado
    {
        public LoteEstado()
        {
            LoteBalanzas = new HashSet<LoteBalanza>();
            LoteChancados = new HashSet<LoteChancado>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
        }

        public string IdLoteEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteBalanza> LoteBalanzas { get; set; }
        public virtual ICollection<LoteChancado> LoteChancados { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
    }
}
