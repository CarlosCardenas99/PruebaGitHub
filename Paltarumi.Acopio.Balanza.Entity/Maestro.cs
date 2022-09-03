using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            Conductors = new HashSet<Conductor>();
            LoteBalanzas = new HashSet<LoteBalanza>();
            LoteCodigoMuestreos = new HashSet<LoteCodigoMuestreo>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
            Lotes = new HashSet<Lote>();
            TicketIdEstadoTmhCarretaNavigations = new HashSet<Ticket>();
            TicketIdEstadoTmhNavigations = new HashSet<Ticket>();
            TicketIdUnidadMedidaNavigations = new HashSet<Ticket>();
            TicketIdUsuarioAprobadorPesoBrutoCarretaNavigations = new HashSet<Ticket>();
            TicketIdUsuarioAprobadorPesoBrutoNavigations = new HashSet<Ticket>();
            VehiculoIdTipoVehiculoNavigations = new HashSet<Vehiculo>();
            VehiculoIdVehiculoMarcaNavigations = new HashSet<Vehiculo>();
        }

        public int IdMaestro { get; set; }
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzas { get; set; }
        public virtual ICollection<LoteCodigoMuestreo> LoteCodigoMuestreos { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhCarretaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUsuarioAprobadorPesoBrutoCarretaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUsuarioAprobadorPesoBrutoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
