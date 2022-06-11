using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class GetLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
        public GetDuenoMuestraDto? DuenoMuestra { get; set; }
        public GetMaestroDto? TipoMineral { get; set; }
    }
}
