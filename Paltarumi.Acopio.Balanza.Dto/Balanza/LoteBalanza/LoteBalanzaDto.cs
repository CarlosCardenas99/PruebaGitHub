namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class LoteBalanzaDto
    {
        public string? CodigoLote { get; set; }
        public string CodigoTrujillo { get; set; } = null!;
        public string CodigoAum { get; set; } = null!;
        public int IdConcesion { get; set; }
        public int IdProveedor { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public int IdEstadoTipoMaterial { get; set; }
        public int? IdTipoMineral { get; set; }
        public int CantidadSacos { get; set; }
        public Single Tmh100 { get; set; }
        public Single TmhBase { get; set; }
        public Single Tmh { get; set; }
        public float? Humedad { get; set; }
        public float? Tms { get; set; }
        public int IdEstado { get; set; }
        public string? Observacion { get; set; }
        public int PorcentajeCheckList { get; set; }
        public string? UserNameCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
    }
}
