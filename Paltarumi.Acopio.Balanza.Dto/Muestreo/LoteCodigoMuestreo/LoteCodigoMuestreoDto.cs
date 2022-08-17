
namespace Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo
{
    public class LoteCodigoMuestreoDto
    {
        public int IdLoteMuestreo { get; set; }
        public int? IdTurno { get; set; }
        public DateTimeOffset? FechaMuestreo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public int? IdDuenoMuestra { get; set; }
        public bool? LlevaGrueso { get; set; }
        public string? IdMuestraCondicion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }

    }
}
