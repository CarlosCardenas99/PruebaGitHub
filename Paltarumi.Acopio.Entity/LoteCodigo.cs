using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LoteCodigo
    {
        public int IdLoteCodigo { get; set; }
        public int IdLoteBalanza { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Codigo { get; set; } = null!;
        public string CodigoHash { get; set; } = null!;
        public int IdEstado { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Activo { get; set; }

        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
    }
}
