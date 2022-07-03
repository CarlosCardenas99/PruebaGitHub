namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteMuestreo
    {
        public int IdLoteMuestreo { get; set; }
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? Fecha { get; set; }
        public int? IdUsuarioSupervisor { get; set; }
        public float Tmh { get; set; }
        public float? Humedad100 { get; set; }
        public float? HumedadBase { get; set; }
        public float? Humedad { get; set; }
        public float? Tms100 { get; set; }
        public float? TmsBase { get; set; }
        public float? Tms { get; set; }
        public int? IdTipoMineral { get; set; }
        public bool? ReportadoProveedor { get; set; }
        public bool? Firmado { get; set; }
        public string IdProveedor { get; set; } = null!;
        public int? IdDuenoMuestra { get; set; }
        public string? Observacion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
