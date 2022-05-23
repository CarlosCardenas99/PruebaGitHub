namespace Paltarumi.Acopio.Entity
{
    public partial class Correlativo
    {
        public int IdCorrelativo { get; set; }
        public string CodigoCorrelativoTipo { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public int Numero { get; set; }
        public bool Activo { get; set; }
    }
}
