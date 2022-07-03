using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Dto.Balanza.LeyReferencial
{
    public class GetLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
        public GetDuenoMuestraDto? DuenoMuestra { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
    }
}
