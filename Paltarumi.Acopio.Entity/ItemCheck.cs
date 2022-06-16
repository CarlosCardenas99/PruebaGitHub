namespace Paltarumi.Acopio.Entity
{
    public partial class ItemCheck
    {
        public ItemCheck()
        {
            CheckLists = new HashSet<CheckList>();
        }

        public int IdItemCheck { get; set; }
        public int IdModulo { get; set; }
        public string Concepto { get; set; } = null!;
        public bool Mandatorio { get; set; }
        public bool Activo { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual ICollection<CheckList> CheckLists { get; set; }
    }
}
