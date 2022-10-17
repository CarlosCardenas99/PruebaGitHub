
namespace Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo
{
    public class LoteMuestreoDto
    {
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public decimal Tmh { get; set; }
        public decimal? PesoHumedo { get; set; }
        public decimal? PesoSeco { get; set; }
        public int? Porcentaje { get; set; }
        public decimal? Humedad100 { get; set; }
        public decimal? HumedadBase { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? Tms100 { get; set; }
        public decimal? TmsBase { get; set; }
        public decimal? Tms { get; set; }
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
        public string? IdLoteEstado { get; set; }
        public string ObservacionBalanza { get; set; } = null!;
    }
}
