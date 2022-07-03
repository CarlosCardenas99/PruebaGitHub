namespace Paltarumi.Acopio.Entity
{
    public partial class ItemCheck
    {
        public ItemCheck()
        {
            CheckLists = new HashSet<CheckList>();
        }

        public int IdItemCheck { get; set; }
        public string Concepto { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<CheckList> CheckLists { get; set; }
    }
}
