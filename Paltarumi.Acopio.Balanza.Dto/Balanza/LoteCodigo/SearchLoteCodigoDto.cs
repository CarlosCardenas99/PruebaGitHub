
namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class SearchLoteCodigoDto
    {
        public int IdLoteCodigo { get; set; }
        public DateTimeOffset FechaRecepcion { get; set; }
        public string? loteCodigo { get; set; }
        public string? Proveedor { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string? DuenoMuestra { get; set; }
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public string? UserNameCreate { get; set; }
        public string Estado { get; set; } = null!;
        public bool Verificado { get; set; }

    }
}
