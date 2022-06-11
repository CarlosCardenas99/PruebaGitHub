using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            LeyReferencials = new HashSet<LeyReferencial>();
            LoteCheckLists = new HashSet<LoteCheckList>();
            LoteIdEstadoNavigations = new HashSet<Lote>();
            LoteIdEstadoTipoMaterialNavigations = new HashSet<Lote>();
            TicketIdEstadoTmhNavigations = new HashSet<Ticket>();
            TicketIdTipoMineralNavigations = new HashSet<Ticket>();
            TicketIdUnidadMedidaNavigations = new HashSet<Ticket>();
            VehiculoIdTipoVehiculoNavigations = new HashSet<Vehiculo>();
            VehiculoIdVehiculoMarcaNavigations = new HashSet<Vehiculo>();
        }

        public int IdMaestro { get; set; }
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<LeyReferencial> LeyReferencials { get; set; }
        public virtual ICollection<LoteCheckList> LoteCheckLists { get; set; }
        public virtual ICollection<Lote> LoteIdEstadoNavigations { get; set; }
        public virtual ICollection<Lote> LoteIdEstadoTipoMaterialNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdTipoMineralNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
