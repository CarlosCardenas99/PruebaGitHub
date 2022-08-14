using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoMuestreo
    {
        public int IdLoteCodigoMuestreo { get; set; }
        public int? IdTurno { get; set; }
        public DateTimeOffset? FechaMuestreo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public string? IdCancha { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public bool? LlevaGrueso { get; set; }
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public float Tmh { get; set; }
        public string? IdMuestraCondicion { get; set; }
        public string? IdMuestraEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual Cancha? IdCanchaNavigation { get; set; }
        public virtual DuenoMuestra? IdDuenoMuestraNavigation { get; set; }
        public virtual MuestraCondicion? IdMuestraCondicionNavigation { get; set; }
        public virtual MuestraEstado? IdMuestraEstadoNavigation { get; set; }
        public virtual Proveedor? IdProveedorNavigation { get; set; }
        public virtual Maestro? IdTurnoNavigation { get; set; }
    }
}
