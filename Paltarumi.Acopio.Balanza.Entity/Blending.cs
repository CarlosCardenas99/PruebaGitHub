using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Blending
    {
        public Blending()
        {
            BlendingLotes = new HashSet<BlendingLote>();
        }

        public int IdBlending { get; set; }
        public int? IdCampaign { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string Numero { get; set; } = null!;
        public decimal Tms { get; set; }
        public decimal AuFinoRec { get; set; }
        public decimal AgFinoRec { get; set; }
        public string IdEstadoReporte { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Campaign? IdCampaignNavigation { get; set; }
        public virtual ICollection<BlendingLote> BlendingLotes { get; set; }
    }
}
