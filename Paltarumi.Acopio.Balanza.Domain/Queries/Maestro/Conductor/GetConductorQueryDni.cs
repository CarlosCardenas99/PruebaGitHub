using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryDni : QueryBase<GetConductorDto>
    {
        public GetConductorQueryDni(string dni) => Dni = dni;
        public string Dni { get; set; }
    }
}
