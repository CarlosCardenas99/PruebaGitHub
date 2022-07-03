namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Ley
    {
        public int IdLey { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public int IdLoteCodigo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public float Tms { get; set; }
        public float? LeyAuGt100 { get; set; }
        public float? LeyAuOzTc100 { get; set; }
        public float? LeyAuGt { get; set; }
        public float? LeyAuOzTc { get; set; }
        public float? Dilucion { get; set; }
        public float? Diferencia { get; set; }
        public float? Total { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
