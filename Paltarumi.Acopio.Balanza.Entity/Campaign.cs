using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Campaign
    {
        public Campaign()
        {
            Blendings = new HashSet<Blending>();
        }

        public int IdCampaign { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string Numero { get; set; } = null!;
        public decimal Tms { get; set; }
        public decimal AuFinoRec { get; set; }
        public decimal AgFinoRec { get; set; }
        public string IdEstadoReporte { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Blending> Blendings { get; set; }
    }
}
