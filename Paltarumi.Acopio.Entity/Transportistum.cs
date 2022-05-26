using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Transportistum
    {
        public Transportistum()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdTransportista { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual TipoDocumento CodigoTipoDocumentoNavigation { get; set; } = null!;
        public virtual Ubigeo? CodigoUbigeoNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
