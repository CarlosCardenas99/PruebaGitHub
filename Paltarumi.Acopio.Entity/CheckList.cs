namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdLoteBalanza { get; set; }
        public int IdModulo { get; set; }
        public int IdItemCheck { get; set; }
        public string Observacion { get; set; } = null!;
        public string Adjunto { get; set; } = null!;
        public bool Habilitado { get; set; }
        public int IdCheckListPadre { get; set; }
        public bool Activo { get; set; }

        public virtual ItemCheck IdItemCheckNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
        public virtual Modulo IdModuloNavigation { get; set; } = null!;
    }
}
