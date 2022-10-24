using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Comisionistum
    {
        public Comisionistum()
        {
            LoteLiquidacionComisions = new HashSet<LoteLiquidacionComision>();
        }

        public int IdComisionistum { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual TipoDocumento CodigoTipoDocumentoNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionComision> LoteLiquidacionComisions { get; set; }
    }
}
