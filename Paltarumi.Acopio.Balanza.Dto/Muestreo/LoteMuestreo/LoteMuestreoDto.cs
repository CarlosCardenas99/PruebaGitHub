
namespace Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo
{
    public class LoteMuestreoDto
    {
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public float Tmh { get; set; }
        public float? PesoHumedo { get; set; }
        public float? PesoSeco { get; set; }
        public float? Humedad100 { get; set; }
        public float? HumedadBase { get; set; }
        public float? Humedad { get; set; }
        public float? Tms100 { get; set; }
        public float? TmsBase { get; set; }
        public float? Tms { get; set; }
        public int? IdTipoMineral { get; set; }
        public string? IdCancha { get; set; }
        public string? IdMineralCondicion { get; set; }
        public bool? ReportadoProveedor { get; set; }
        public bool? Firmado { get; set; }
        public int IdProveedor { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public string? Observacion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
    }
}
