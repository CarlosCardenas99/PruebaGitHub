using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            CheckListIdCheckListConceptoNavigations = new HashSet<CheckList>();
            CheckListIdEstadoChecklistNavigations = new HashSet<CheckList>();
            CheckListIdModuloOrigenNavigations = new HashSet<CheckList>();
            LeyReferencials = new HashSet<LeyReferencial>();
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

        public virtual ICollection<CheckList> CheckListIdCheckListConceptoNavigations { get; set; }
        public virtual ICollection<CheckList> CheckListIdEstadoChecklistNavigations { get; set; }
        public virtual ICollection<CheckList> CheckListIdModuloOrigenNavigations { get; set; }
        public virtual ICollection<LeyReferencial> LeyReferencials { get; set; }
        public virtual ICollection<Lote> LoteIdEstadoNavigations { get; set; }
        public virtual ICollection<Lote> LoteIdEstadoTipoMaterialNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdTipoMineralNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
