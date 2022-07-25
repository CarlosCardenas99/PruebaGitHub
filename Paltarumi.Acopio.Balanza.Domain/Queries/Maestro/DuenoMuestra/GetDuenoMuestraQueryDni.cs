using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQueryDni : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraQueryDni(string dni) => Dni = dni;
        public string Dni { get; set; }
    }
}
