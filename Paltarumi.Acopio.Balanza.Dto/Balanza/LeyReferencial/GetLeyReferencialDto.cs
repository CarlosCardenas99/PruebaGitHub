using Paltarumi.Acopio.Maestros.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Balanza.Dto.LeyReferencial
{
    public class GetLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
        public GetDuenoMuestraDto? DuenoMuestra { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
    }
}
