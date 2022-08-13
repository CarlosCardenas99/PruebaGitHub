
namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class LoteCodigoDto
    {
        public int? IdLote { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public bool EsInterno { get; set; }
        public string IdLoteCodigoTipo { get; set; } = null!;
        public DateTimeOffset FechaRecepcion { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public string CodigoMuestraProveedor { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }

    }
}
