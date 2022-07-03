using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

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
