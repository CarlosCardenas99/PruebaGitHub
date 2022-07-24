using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            Conductors = new HashSet<Conductor>();
            LoteBalanzaIdEstadoNavigations = new HashSet<LoteBalanza>();
            LoteBalanzaIdEstadoTipoMaterialNavigations = new HashSet<LoteBalanza>();
            LoteCodigoNomenclaturas = new HashSet<LoteCodigoNomenclatura>();
            LoteCodigos = new HashSet<LoteCodigo>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
            MuestraIdCanchaNavigations = new HashSet<Muestra>();
            MuestraIdMuestraCondicionNavigations = new HashSet<Muestra>();
            MuestraIdMuestraEstadoNavigations = new HashSet<Muestra>();
            MuestraIdTurnoNavigations = new HashSet<Muestra>();
            TicketDocIdEstadoTmhCarretaNavigations = new HashSet<TicketDoc>();
            TicketDocIdEstadoTmhNavigations = new HashSet<TicketDoc>();
            TicketDocIdUnidadMedidaNavigations = new HashSet<TicketDoc>();
            TicketDocIdUsuarioAprobadorPesoBrutoCarretaNavigations = new HashSet<TicketDoc>();
            TicketDocIdUsuarioAprobadorPesoBrutoNavigations = new HashSet<TicketDoc>();
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
        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoNavigations { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoTipoMaterialNavigations { get; set; }
        public virtual ICollection<LoteCodigoNomenclatura> LoteCodigoNomenclaturas { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
        public virtual ICollection<Muestra> MuestraIdCanchaNavigations { get; set; }
        public virtual ICollection<Muestra> MuestraIdMuestraCondicionNavigations { get; set; }
        public virtual ICollection<Muestra> MuestraIdMuestraEstadoNavigations { get; set; }
        public virtual ICollection<Muestra> MuestraIdTurnoNavigations { get; set; }
        public virtual ICollection<TicketDoc> TicketDocIdEstadoTmhCarretaNavigations { get; set; }
        public virtual ICollection<TicketDoc> TicketDocIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<TicketDoc> TicketDocIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<TicketDoc> TicketDocIdUsuarioAprobadorPesoBrutoCarretaNavigations { get; set; }
        public virtual ICollection<TicketDoc> TicketDocIdUsuarioAprobadorPesoBrutoNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhCarretaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUsuarioAprobadorPesoBrutoCarretaNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUsuarioAprobadorPesoBrutoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
