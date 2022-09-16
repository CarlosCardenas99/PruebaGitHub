using Paltarumi.Acopio.Audit.Entity.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class LoteCodigoMuestreo
    {
        public int IdLoteCodigoMuestreo { get; set; }
        public int IdLoteMuestreo { get; set; }
        public int? IdTurno { get; set; }
        public DateTimeOffset? FechaMuestreo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public int? IdDuenoMuestra { get; set; }
        public bool? LlevaGrueso { get; set; }
        public string? IdMuestraCondicion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        public virtual DuenoMuestra? IdDuenoMuestraNavigation { get; set; }
        public virtual LoteMuestreo IdLoteMuestreoNavigation { get; set; } = null!;
        public virtual MuestraCondicion? IdMuestraCondicionNavigation { get; set; }
        public virtual Maestro? IdTurnoNavigation { get; set; }
    }
}
