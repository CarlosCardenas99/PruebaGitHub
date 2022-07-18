
namespace Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo
{
    public class LoteMuestreoDto
    {
        public string? CodigoLote { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string? UserNameSupervisor { get; set; }
        public Single Tmh { get; set; }
        public Single? Humedad100 { get; set; }
        public Single? HumedadBase { get; set; }
        public Single? Humedad { get; set; }
        public Single? Tms100 { get; set; }
        public Single? TmsBase { get; set; }
        public Single? Tms { get; set; }
        public int? IdTipoMineral { get; set; }
        public bool? ReportadoProveedor { get; set; }
        public bool? Firmado { get; set; }
        public int IdProveedor { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public string? Observacion { get; set; }
        public string? UserNameCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
