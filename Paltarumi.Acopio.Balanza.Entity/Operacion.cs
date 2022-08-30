using Paltarumi.Acopio.Balanza.Entity.Audit;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class Operacion
    {
        public Operacion()
        {
            LoteOperacions = new HashSet<LoteOperacion>();
        }

        public int IdOperacion { get; set; }
        public int IdModulo { get; set; }
        public string Codigo { get; set; } = null!;
        public string PushUrl { get; set; } = null!;
        public string NotificationEmail { get; set; } = null!;

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual ICollection<LoteOperacion> LoteOperacions { get; set; }
    }
}
