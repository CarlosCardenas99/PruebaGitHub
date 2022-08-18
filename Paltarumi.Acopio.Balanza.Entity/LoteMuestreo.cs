using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteMuestreo
    {
        public LoteMuestreo()
        {
            LoteCodigoMuestreos = new HashSet<LoteCodigoMuestreo>();
        }

        public int IdLoteMuestreo { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public float Tmh { get; set; }
        public float? PesoHumedo { get; set; }
        public float? PesoSeco { get; set; }
        public float? Humedad100 { get; set; }
        public float? HumedadBase { get; set; }
        public float? Humedad { get; set; }
        public float? Tms100 { get; set; }
        public float? TmsBase { get; set; }
        public float? Tms { get; set; }
        public int? IdTipoMineral { get; set; }
        public string? IdCancha { get; set; }
        public string? IdMineralCondicion { get; set; }
        public bool? ReportadoProveedor { get; set; }
        public bool? Firmado { get; set; }
        public int IdProveedor { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public string? Observacion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual Cancha? IdCanchaNavigation { get; set; }
        public virtual DuenoMuestra? IdDuenoMuestraNavigation { get; set; }
        public virtual MineralCondicion? IdMineralCondicionNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual Maestro? IdTipoMineralNavigation { get; set; }
        public virtual ICollection<LoteCodigoMuestreo> LoteCodigoMuestreos { get; set; }
    }
}
