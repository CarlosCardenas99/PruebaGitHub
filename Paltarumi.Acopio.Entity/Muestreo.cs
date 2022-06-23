namespace Paltarumi.Acopio.Entity
{
    public partial class Muestreo
    {
        public int IdMuestreo { get; set; }
        public int CodigoTurno { get; set; }
        public int CodigoResponsable { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public int IdLote { get; set; }
        public int CodigoCancha { get; set; }
        public bool LlevaGrueso { get; set; }
        public string CodigoTrujillo { get; set; } = null!;
        public string CodigoAum { get; set; } = null!;
        public int IdEncargado { get; set; }
        public int CodigoCondicion { get; set; }
        public int CodigoEstado { get; set; }
        public bool Activo { get; set; }
    }
}
