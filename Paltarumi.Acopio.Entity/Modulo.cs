namespace Paltarumi.Acopio.Entity
{
    public partial class Modulo
    {
        public Modulo()
        {
            CheckLists = new HashSet<CheckList>();
            ItemChecks = new HashSet<ItemCheck>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;
        public int Nivel { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<ItemCheck> ItemChecks { get; set; }
    }
}
