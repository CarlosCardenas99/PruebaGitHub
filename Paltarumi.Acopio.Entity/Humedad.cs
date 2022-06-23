namespace Paltarumi.Acopio.Entity
{
    public partial class Humedad
    {
        public int IdHumedad { get; set; }
        public int IdLote { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public float Tmh { get; set; }
        public float Tms { get; set; }
        public float Humedad100 { get; set; }
        public float Humedad1 { get; set; }
        public int CodigoMuestreoTipoMineral { get; set; }
        public int CodigoSupervisor { get; set; }
        public bool ReportadoProveedor { get; set; }
        public bool Firmado { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
