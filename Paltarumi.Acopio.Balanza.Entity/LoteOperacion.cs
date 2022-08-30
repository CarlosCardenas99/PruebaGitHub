using Paltarumi.Acopio.Balanza.Entity.Audit;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class LoteOperacion
    {
        public int IdLoteOperacion { get; set; }
        public int IdLote { get; set; }
        public int IdOperacion { get; set; }
        public string Status { get; set; } = null!;
        public string? Message { get; set; }
        public string? Body { get; set; }
        public int? Attempts { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }

        public virtual Lote IdLoteNavigation { get; set; } = null!;
        public virtual Operacion IdOperacionNavigation { get; set; } = null!;
    }
}
