namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class LoteBalanzaDto
    {
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public int IdConcesion { get; set; }
        public int IdProveedor { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public int IdEstadoTipoMaterial { get; set; }
        public int CantidadSacos { get; set; }
        public float Tmh100 { get; set; }
        public float TmhBase { get; set; }
        public float Tmh { get; set; }
        public float? Humedad { get; set; }
        public float? Tms { get; set; }
        public string Observacion { get; set; } = null!;
        public int PorcentajeCheckList { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string IdLoteEstado { get; set; } = null!;
    }
}
