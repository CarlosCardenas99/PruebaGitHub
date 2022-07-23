using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Transporte
    {
        public Transporte()
        {
            TicketDocs = new HashSet<TicketDoc>();
            Tickets = new HashSet<Ticket>();
            TransporteVehiculos = new HashSet<TransporteVehiculo>();
        }

        public int IdTransporte { get; set; }
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Ubigeo? CodigoUbigeoNavigation { get; set; }
        public virtual ICollection<TicketDoc> TicketDocs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TransporteVehiculo> TransporteVehiculos { get; set; }
    }
}
