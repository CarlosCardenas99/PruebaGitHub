
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class LeyReferencialDto
    {
        public DateTime FechaRecepcion { get; set; }
        public int IdDuenoMuestra { get; set; }
        public int? IdProveedor { get; set; }
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public int? IdTipoMineral { get; set; }
        public int CodigoLaboratorio { get; set; }
        public bool LeyAu { get; set; }
        public bool LeyAg { get; set; }
        public bool PorcentajeRecuperacion { get; set; }
        public bool Consumos { get; set; }
    }
}
