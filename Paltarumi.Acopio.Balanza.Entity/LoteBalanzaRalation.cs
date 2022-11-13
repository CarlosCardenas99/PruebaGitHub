using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteBalanzaRalation
    {
        public int IdLoteBalanzaRalation { get; set; }
        public int IdLoteBalanzaOrigin { get; set; }
        public int IdLoteBalanzaDestination { get; set; }
        public bool Activo { get; set; }

        public virtual LoteBalanza IdLoteBalanzaDestinationNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaOriginNavigation { get; set; } = null!;
    }
}
